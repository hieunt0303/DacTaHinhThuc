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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        //hàm xác định loại tham số đầu vào
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
        // test thử hàm nhập 
        private void HamNhap(List<string> input, string str2, int loai)
        {

            string nhap = "";
            string nhap2 = "";
            string ts = "";
            string[] temp1 = str2.Split(new[] { ",", ":", "(", ")" }, StringSplitOptions.None);

            for (int i = 1; i < temp1.Length; i++)
            {
                if (temp1[i] == "R")
                {
                    nhap = "int" + temp[i - 1];
                    nhap2 = "int";

                }
                else if (temp1[i] == "N")
                {
                    nhap = "double" + temp[i - 1];
                    nhap2 = "double";
                }
                else if (temp1[i] == "char")
                {
                    nhap = "char" + temp[i - 1];

                }
            }


            if (loai == 1)   // xet 2 ham Max2so + Max2SoDuong
            {

                string tenham = string.Format(" \t\t public void Nhap(ref {0} {1} ,ref {0} {2}) ", nhap2, temp1[1], temp1[3]);
                string loainhap1 = string.Format("\t\t\t Console.WriteLine( \" nhap {0} \");", temp1[1]);
                string doc1 = string.Format("\t\t\t {0} = {1}.Parse(Console.Readline()); ", temp1[1], nhap2);
                string loainhap2 = string.Format("\t\t\t Console.WriteLine( \" nhap {0} \");", temp1[3]);
                string doc2 = string.Format("\t\t\t {0} = {1}.Parse(Console.Readline()); ", temp1[3], nhap2);
                input.Add(tenham);
                input.Add("\t\t{");
                input.Add(loainhap1);
                input.Add(doc1);
                input.Add(loainhap2);
                input.Add(doc2);
                input.Add("\t\t}");
            }
            else if (loai == 2)  // pt bac 1
            {
                string tenham = string.Format(" \t\t public void Nhap(ref {0} {1} ,ref {0} {2}) ", nhap2, temp1[1], temp1[3]);
                string loainhap1 = string.Format("\t\t\t Console.WriteLine( \" nhap {0} \");", temp1[1]);
                string doc1 = string.Format("\t\t\t {0} = {1}.Parse(Console.Readline()); ", temp1[1], nhap2);
                string loainhap2 = string.Format("\t\t\t Console.WriteLine( \" nhap {0} \");", temp1[3]);
                string doc2 = string.Format("\t\t\t {0} = {1}.Parse(Console.Readline()); ", temp1[3], nhap2);
                input.Add(tenham);
                input.Add("\t\t{");
                input.Add(loainhap1);
                input.Add(doc1);
                input.Add(loainhap2);
                input.Add(doc2);
                input.Add("\t\t}");
            }
            else if (loai == 3)  // xep loai hs
            {
                string tenham = string.Format(" \t\t public void Nhap(ref {0} {1} ,ref {0} {2}) ", nhap2, temp1[1], temp1[3]);
                string loainhap1 = string.Format("\t\t\t Console.WriteLine( \" nhap diem {0} \");", temp1[1]);
                string doc1 = string.Format("\t\t\t {0} = {1}.Parse(Console.Readline()); ", temp1[1], nhap2);

                input.Add(tenham);
                input.Add("\t\t{");
                input.Add(loainhap1);
                input.Add(doc1);
                input.Add("\t\t}");
            }
            else if (loai == 4) // nam nhuan
            {
                string tenham = string.Format(" \t\t public void Nhap(ref {0} {1} ,ref {0} {2}) ", nhap2, temp1[1], temp1[3]);
                string loainhap1 = string.Format("\t\t\t Console.WriteLine( \" nhap nam {0} \");", temp1[1]);
                string doc1 = string.Format("\t\t\t {0} = {1}.Parse(Console.Readline()); ", temp1[1], nhap2);

                input.Add(tenham);
                input.Add("\t\t{");
                input.Add(loainhap1);
                input.Add(doc1);
                input.Add("\t\t}");
            }

        }
        // ham xuat
        private void HamXuat(List<string> input, int loai, string str2)
        {
            string nhap = "";
            string nhap2 = "";
            string ts = "";
            string[] temp1 = str2.Split(new[] { ",", ":", "(", ")" }, StringSplitOptions.None);

            for (int i = 1; i < temp1.Length; i++)
            {
                if (temp1[i] == "R")
                {
                    nhap = "int" + temp[i - 1];
                    nhap2 = "int";

                }
                else if (temp1[i] == "N")
                {
                    nhap = "double" + temp[i - 1];
                    nhap2 = "double";
                }
                else if (temp1[i] == "char")
                {
                    nhap = "char" + temp[i - 1];

                }
                // gan noi dung 
            }
            if (loai == 1)   // xet 2 ham Max2so + Max2SoDuong
            {

                string tenham = string.Format(" \t\t public void Xuat(ref {0} {1}) ", nhap2, temp1[5]);
                string loainhap1 = string.Format("\t\t\t Console.WriteLine( \" ket qua la {0} \",{0});", temp1[5]);          

                input.Add(tenham);
                input.Add("\t\t{");
                input.Add(loainhap1);
               
                input.Add("\t\t}");
            }
            else if (loai == 2)  // pt bac 1
            {
                string tenham = string.Format(" \t\t public void Xuat(ref {0} {1}) ", nhap2, temp1[5]);
                string loainhap1 = string.Format("\t\t\t Console.WriteLine( \" ket qua la : {0} \",{0});", temp1[4]);


                input.Add(tenham);
                input.Add("\t\t{");
                input.Add(loainhap1);


                input.Add("\t\t}");
            }
            else if (loai == 3)  // xep loai hs
            {
                string tenham = string.Format(" \t\t public void Xuat(ref {0} {1}) ", nhap2, temp1[5]);
                string loainhap1 = string.Format("\t\t\t Console.WriteLine( \" xep loai la {0} \",{0});", temp1[4]);


                input.Add(tenham);
                input.Add("\t\t{");
                input.Add(loainhap1);

                input.Add("\t\t}");
            }
            else if (loai == 4) // nam nhuan
            {
                string tenham = string.Format(" \t\t public void Xuat(ref {0} {1}) ", nhap2, temp1[5]);
                string loainhap1 = string.Format("\t\t\t Console.WriteLine( \" nhap nam {0} \");", temp1[4]);


                input.Add(tenham);
                input.Add("\t\t{");
                input.Add(loainhap1);

                input.Add("\t\t}");
            }
        }
    


        private void button1_Click(object sender, EventArgs e)
        {

            string[] line = textINPUT.Text.Split("/n");
            //hàm split tách lấy tên hàm 
            check1 = line[0].IndexOf("(");
            check2 = line[0].Length;
            str1 = line[0].Substring(0, check1);
            // tách tham số đầu vào 
            str2 = line[0].Substring(check1);
            temp = str2.Split(new[] { ",", ":","(",")" }, StringSplitOptions.None);
            //SetVari(str2);

            CheckLoai(str1);
            Setoutput(str1);
            HamNhap(OutPut, str2, loai);
            HamXuat(OutPut, loai, str2);
            CheckText();


            

            textOUTPUT.Text = string.Join(Environment.NewLine, OutPut.ToArray());
            //textOUTPUT.Text = string.Join(Environment.NewLine, temp.ToArray());


        }
        //hàm tách các phần input 
        private void DivINPUT()
        {
            /*string[] line = textINPUT.Text.Split("/n");
            check1 = line[0].IndexOf("(");
            str1 = line[0].Substring(0, check1);
            str2 = line[0].Substring(check1, line[0].Length);*/

        }
        //test hàm check tên chương trình
        private int  CheckLoai(string str)
        {
            if (str == "Max2So")
            {
                // textOUTPUT.Text = "fuction tim max 2 so";
                loai = 1;
            }

            else if (str == "Giaiptbac1")
            {
                //textOUTPUT.Text = "fuction giai pt bac 1";
                loai = 2;
            }
            else if (str == "XeploaiHS")
            {
                textOUTPUT.Text = "fuction xep loai";
                loai = 3;
            }

            else
                //textOUTPUT.Text = "khong xac dinh dc";
                loai = 0;

            return loai;


        }
        private void CheckTS(string strr,int a)
        {
            int TS=0;
            var  c = ":";
            string[] kiemtra = strr.Split();
            for(int i =0; i < strr.Length; i++)
            {
                

            }
        }
        //test hàm gắn thân OutPut dựa qua tên chương trình 
        private void Setoutput(string str)
        {
            OutPut.Add("using System;");
            if (CheckLoai(str1) == 1)
            {
                OutPut.Add("Namepsace TimMax2So");
                OutPut.Add("{");
                OutPut.Add("\t Public Class Max2So");
            }
            else if (CheckLoai(str1) == 2)
            {
                OutPut.Add("Namepsace GiaiPTbac1");
                OutPut.Add("{");
                OutPut.Add("\t Public Class giaipt1");
            }
            else if (CheckLoai(str1) == 3)
            {
                OutPut.Add("Namepsace XepLoai");
                OutPut.Add("{");
                OutPut.Add("\t Public Class XepLoaiHS");
            }
            else
            {
                OutPut.Add("Namepsace Test");
                OutPut.Add("{");
                OutPut.Add("\t Public Class Test");
            }
            OutPut.Add("\t\t{");
            

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
    }
}
