using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
        string str1;
        string str2;
        int check1;
        int check2;
        string kq;
        int loai;
        string inputPath;

        string namePath;
        string prePath;
        string postPath;

        NameFunction namefun = new NameFunction();
        PreFunction prefun = new PreFunction();
        PostFunction postfun = new PostFunction();

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
       


        private void button1_Click(object sender, EventArgs e)
        {

            if (textINPUT.Text == " ")
                textOUTPUT.Text = " ";
            else
            {
                List<string> Output = new List<string>();
                Setoutput(Output);
                SetFunctionPath();
                namefun.HamNhap(Output, namePath);
                namefun.HamXuat(Output, namePath);
                prefun.CheckState(Output, prePath);
                postfun.SetStatement(Output, postPath, namePath);
                namefun.SetMain(Output, namePath);


                textOUTPUT.Text = string.Join(Environment.NewLine, Output.ToArray());

                CheckText();
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
    }
}
