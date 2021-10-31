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


        public void SetVari(string strc)
        {
            

        }
        // hàm chung output tên hàm 
        public string  SetNamePG(string NameFunc,string namePath,int loai)
        {
            if (NameFunc == "Xuat")
            {
                string[] lines = namePath.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] vari = lines[2].Split(new[] { ":" }, StringSplitOptions.None);
                string funname = string.Format("\t\tpublic void {1}{0}(", lines[0], NameFunc);
                for (int i = 0; i < vari.Length; i += 2)
                {
                    if (vari[i + 1] == "R")
                    {
                        funname += "float ";
                    }
                    else if (vari[i + 1] == "Z")
                    {
                        funname += "int ";
                    }
                    else if (vari[i + 1] == "B")
                    {
                        funname += "bool ";
                    }
                    else if (vari[i + 1] == "char*")
                    {
                        funname += "string ";
                    }
                    string varName = string.Format("{0}", vari[i]);
                    funname += varName;
                }
                funname += ")";
                return funname;
            }
            else if (NameFunc == "")
            {
                string[] lines = namePath.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] vari = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                string funname = string.Format("\t\tpublic {2}{1}{0}(", lines[0], NameFunc, loai);
                for (int i = 0; i < vari.Length; i += 2)
                {
                    if (vari[i + 1] == "R")
                    {
                        funname += "float ";
                    }
                    else if (vari[i + 1] == "Z")
                    {
                        funname += "int ";
                    }
                    else if (vari[i + 1] == "B")
                    {
                        funname += "bool ";
                    }
                    else if (vari[i + 1] == "char*")
                    {
                        funname += "string ";
                    }
                    if (i == 0)
                    {
                        if (i + 2 >= vari.Length)
                        {
                            string varName = string.Format("{0} ", vari[i]);
                            funname += varName;
                        }
                        else
                        {
                            string varName = string.Format("{0}, ", vari[i]);
                            funname += varName;
                        }
                    }
                    else
                    {
                        string varName = string.Format("{0}", vari[i]);
                        funname += varName;
                    }
                }
                funname += ")";
                return funname;
            }
            else if (NameFunc == "KiemTra")
            {
                string[] lines = namePath.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] vari = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                string funname = string.Format("\t\tpublic int {1}{0}(", lines[0], NameFunc, loai);
                for (int i = 0; i < vari.Length; i += 2)
                {
                    if (vari[i + 1] == "R")
                    {
                        funname += "float ";
                    }
                    else if (vari[i + 1] == "Z")
                    {
                        funname += "int ";
                    }
                    else if (vari[i + 1] == "B")
                    {
                        funname += "bool ";
                    }
                    else if (vari[i + 1] == "char*")
                    {
                        funname += "string ";
                    }
                    if (i == 0)
                    {
                        if (i + 2 >= vari.Length)
                        {
                            string varName = string.Format("{0} ", vari[i]);
                            funname += varName;
                        }
                        else
                        {
                            string varName = string.Format("{0}, ", vari[i]);
                            funname += varName;
                        }
                    }
                    else
                    {
                        string varName = string.Format("{0}", vari[i]);
                        funname += varName;
                    }
                }
                funname += ")";
                return funname;
            }
            else
            {
                string[] lines = namePath.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] vari = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                string funname = string.Format("\t\tpublic void {1}{0}(", lines[0], NameFunc);
                for (int i = 0; i < vari.Length; i += 2)
                {
                    if (vari[i + 1] == "R")
                    {
                        funname += "ref float ";
                    }
                    else if (vari[i + 1] == "Z")
                    {
                        funname += "ref int ";
                    }
                    else if (vari[i + 1] == "B")
                    {
                        funname += "ref bool ";
                    }
                    else if (vari[i + 1] == "char*")
                    {
                        funname += "ref string ";
                    }
                    if (i == 0)
                    {
                        if (i + 2 >= vari.Length)
                        {
                            string varName = string.Format("{0} ", vari[i]);
                            funname += varName;
                        }
                        else
                        {
                            string varName = string.Format("{0}, ", vari[i]);
                            funname += varName;
                        }
                    }
                    else
                    {
                        string varName = string.Format("{0}", vari[i]);
                        funname += varName;
                    }
                }
                funname += ")";
                return funname;
            }
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
