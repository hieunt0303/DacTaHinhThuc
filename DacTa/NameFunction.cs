using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace DacTa
{
    public class NameFunction
    {
        string NameFunc;
        string txtOut;
        int loai;
        string[] stringOut;
        string namePG;
        string[] temp;


        public int CheckType(string strc)
        {
            if (strc == "Max2So")
            {

                loai = 1;
            }

            else if (strc == "Giaiptbac1")
            {

                loai = 2;
            }
            else if (strc == "XeploaiHS")
            {

                loai = 3;
            }

            else
                loai = 4;
            return loai;

        }
        public string  SetNamePG(int loai)
        {
            string name="";
            
            if(loai == 1)
            {
                name = "TimMax2So";
                
            }
            else if (loai == 2)
            {
                name  = "GiaiPhuongTrinh";
               
            }
            else if (loai == 3)
            {
                 name = "XepLoaiHocSinh";
                
            }
            return namePG = "namespace "+name;
        }
        public void HamNhap(List<string> input, string str2, int loai)
        {
            
            string nhap = "";
            string nhap2 = "";
            string ts = "";
            string[] temp1 = str2.Split(new[] { ",", ":", "(", ")" }, StringSplitOptions.None);
           
            for (int i = 1; i < temp1.Length; i++)
            {
                if (temp1[i] == "R")
                {
                    nhap = "int" + temp[i - 1]  ;
                    nhap2 = "int";
                    
                }
                else if (temp1[i] == "N")
                {
                    nhap = "double" + temp[i - 1] ;
                    
                }
                else if (temp1[i] == "char")
                {
                    nhap = "char" + temp[i - 1] ;
                    
                }
            }
            if (loai == 1)
            {
                
                string tenham = string.Format("/t/t public void Nhap(ref {0} {1} ,ref {3} {4}) ",nhap2,temp1[0],nhap2,temp1[2]);
                string loainhap1 = string.Format("/t/t/t Console.WriteLine( \" nhap {0} \");",temp1[0]);
                string doc1 = string.Format("/t/t/t {0} = {1}.Parse(Console.Readline()); ", temp1[0], nhap2);
                string loainhap2 = string.Format("/t/t/t Console.WriteLine( \" nhap {0} \");", temp1[2]);
                string doc2 = string.Format("/t/t/t {0} = {1}.Parse(Console.Readline()); ", temp1[2], nhap2);
                input.Add(tenham);
                input.Add("/t/t{");
                input.Add(loainhap1);
                input.Add(doc1);
                input.Add(loainhap2);
                input.Add(doc2);
                input.Add("/t/t}");
            }
            else if (loai == 2)
            {
                input.Add("/t/t public void NhapDiem()");
                input.Add("/t/t/t{");
            }
        } 
    }
    

}
