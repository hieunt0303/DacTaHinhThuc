using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;


namespace DacTa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> OutPut = new List<string>();


        string[] temp;  // mảng giữ biến   
        string str2;
             
        string inputPath;

        string namePath;
        string prePath;
        string postPath;

        NameFunction namefun = new NameFunction();
        PreFunction prefun = new PreFunction();
        PostFunction postfun = new PostFunction();

        pyNameFunction pynamefun = new pyNameFunction();
        pyPreFunction pyprefun = new pyPreFunction();
        pyPostFunction pypostfun = new pyPostFunction();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        // hàm chia các phần name,pre,post
        public void SetFunctionPath()
        {
            int postX;
            int preX;
            int last;
            inputPath = textINPUT.Text;
            string cut = inputPath.Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty).Replace(" ", string.Empty);
            preX = cut.IndexOf("pre");
            postX = cut.IndexOf("post");
            last = cut.Length;
            namePath = cut.Substring(0, preX);
            prePath = cut.Substring(preX, postX-preX);
            postPath = cut.Substring(postX,last-postX);

        }
        //hàm test xác định loại tham số đầu vào
        private void SetVari(string arry)
        {
            string nhap = "";
            string[] temp1 = str2.Split(new[] { ",", ":", "(", ")" }, StringSplitOptions.None);
            for (int i = 1; i < temp1.Length; i++)
            {
                if (temp1[i] == "R")
                {
                    nhap = "int" + temp[i - 1] + ";";
                    OutPut.Add(nhap);
                }
                else if (temp1[i] == "N")
                {
                    nhap = "double" + temp[i - 1] + ";";
                    OutPut.Add(nhap);
                }
                else if (temp1[i] == "char")
                {
                    nhap = "char" + temp[i - 1] + ";";
                    OutPut.Add(nhap);
                }
            }
        }
       

        // button run
        private void button1_Click(object sender, EventArgs e)
        {
            if (textINPUT.Text == " ")
                textOUTPUT.Text = " ";
            else
            {
                if (comboBox1.Text == "")
                    MessageBox.Show("Please choose language you want to run.");
                else
                {
                    if (comboBox1.Text == "C#")
                    {
                        List<string> Output = new List<string>();
                        Setoutput(Output);
                        SetFunctionPath();
                        namefun.HamNhap(Output, namePath);
                        namefun.HamXuat(Output, namePath);
                        prefun.CheckState(Output, prePath, namePath);
                        postfun.SetStatement(Output, postPath, namePath);
                        namefun.SetMain(Output, namePath);
                        Output.Add("\t}");
                        Output.Add("}");


                        textOUTPUT.Text = string.Join(Environment.NewLine, Output.ToArray());

                        CheckText();
                    }
                    else if (comboBox1.Text == "Python")
                    {
                        List<string> Output = new List<string>();
                        SetFunctionPath();
                        pynamefun.HamNhap(Output, namePath);
                        pynamefun.HamXuat(Output, namePath);
                        pyprefun.CheckState(Output, prePath, namePath);
                        pypostfun.SetStatement(Output, postPath, namePath);
                        pynamefun.SetMain(Output, namePath);

                        textOUTPUT.Text = string.Join(Environment.NewLine, Output.ToArray());

                        CheckText();
                    }
                }
            }
        }
        
        
        //test hàm gắn thân OutPut dựa qua tên chương trình 
        public void Setoutput(List<string> input)
        {
            input.Add("using System;");
            input.Add("namespace FormalSpecification");
            input.Add("{");//name space
            input.Add(string.Format("\tpublic class Program"));
            input.Add("\t{");


        }
      
        
        // nút open file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string fileName;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
               
                StreamReader readFile = new StreamReader(fileName);
                textINPUT.Text = readFile.ReadToEnd();
                readFile.Close();
            }
                       textOUTPUT.Text = "";

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textINPUT.Clear();
            textOUTPUT.Clear();

        }
       


        // hàm highlight
        private void HighLight(RichTextBox richTextBox, string[] find, int ColorCase)
        {
            for (int i = 0; i < find.Length; i++)
            {
                int index = 0;
                string findword = find[i];
                RichTextBox temp = richTextBox;
                while (index <= temp.Text.LastIndexOf(findword) && (index != -1))
                {
                    temp.Find(findword, index, temp.TextLength, RichTextBoxFinds.None);
                    if (temp.Find(findword, index, temp.TextLength, RichTextBoxFinds.None) != 0)
                    {
                        string str = temp.Text.Substring(temp.Find(findword, index, temp.TextLength, RichTextBoxFinds.None) - 1, 1);
                        if (hasSpecialChar(str))
                        {
                            switch (ColorCase)
                            {
                                case 1:
                                    temp.SelectionColor = Color.Blue;
                                    break;
                                case 2:
                                    temp.SelectionColor = Color.Red;
                                    break;
                                case 3:
                                    temp.SelectionColor = Color.Brown;
                                    break;
                                case 4:
                                    temp.SelectionColor = Color.Green;
                                    break;
                            }
                        }
                    }
                    else
                        temp.SelectionColor = Color.Blue;
                    index = temp.Text.IndexOf(findword, index + 1);
                }
                richTextBox = temp;
            }
        }
        // hàm check các ký tự toán tử
        public static bool hasSpecialChar(string input)
        {
            string[] checkstr = { "\t", "\n", "(", ")", ":", "&", " ", "=" };
            foreach (var item in checkstr)
            {
                if (input == item)
                    return true;
            }
            return false;
        }
        // hàm check các loại 
        public String[] CaseText(int CaseColor)
        {
            string[] str = { };
            if (CaseColor == 1)
            {
                str = new string[] { "pre", "post", "if", "else", "namespace", "Public", "static", "void", "Class", "ref", "return", "int", "float", "double", "string", "new", "using" };
            }
            else if (CaseColor == 2)
            {
                str = new string[] { "R" };
            }
            else if (CaseColor == 3)
            {
                str = new string[] { "&&", "||", "Program" };
            }
            else if (CaseColor == 4)
            {
                str = new string[] { "Console" };
            }
            return str;
        }
        public void CheckText()
        {
            for (int i = 1; i <= 4; i++)
            {
                this.HighLight(textINPUT, CaseText(i), i);
                this.HighLight(textOUTPUT, CaseText(i), i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // run
        private void button1_Click_1(object sender, EventArgs e)
        {
            

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            string Output = "Out.exe";
            Button ButtonObject = (Button)sender;

            txtInfo.Text = "";
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            //Make sure we generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, textOUTPUT.Text);
            
            if (results.Errors.Count > 0)
            {
                txtInfo.ForeColor = Color.Red;
                foreach (CompilerError CompErr in results.Errors)
                {
                    txtInfo.Text = txtInfo.Text +
                                "Line number " + CompErr.Line +
                                ", Error Number: " + CompErr.ErrorNumber +
                                ", '" + CompErr.ErrorText + ";" +
                                Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                //Successful Compile
                //textBox2.ForeColor = Color.Blue;
                //textBox2.Text = "Success!";
                //If we clicked run then launch our EXE
                if (ButtonObject.Text == "Run") Process.Start(Output);
                
            }
        }

        private void txbNameFile_MouseClick(object sender, MouseEventArgs e)
        {
            txbNameFile.Clear();
        }

        private void textOUTPUT_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult save_yes_no = MessageBox.Show("Do you want to save the text ?", "Save", MessageBoxButtons.YesNo);
            if (save_yes_no == DialogResult.Yes)
            {
                SaveFileDialog file_save = new SaveFileDialog();
                if (file_save.ShowDialog() == DialogResult.OK)
                {
                    //yes ???

                    FileStream fParameter = new FileStream(file_save.FileName + ".txt", FileMode.Create, FileAccess.Write);
                    StreamWriter m_WriterParameter = new StreamWriter(fParameter);
                    m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
                    m_WriterParameter.Write(textOUTPUT.Text);
                    m_WriterParameter.Flush();
                    m_WriterParameter.Close();
                }
            }
            else
            {
                //no ???
                

            }
        }
    }
}
