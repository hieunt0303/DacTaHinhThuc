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
        string loai;
        string[] stringOut;
        string namePG;
        string[] temp;


        public void SetVari(string strc)
        {
            

        }
        // hàm chung output tên hàm 
        public string  SetNamePG(string NameFunc,string namePath,string loai)
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
    
        public void HamNhap(List<string> input, string namepath)
        {
            string[] path = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] vari = path[1].Split(new[] { ":", "," }, StringSplitOptions.None);
           
                input.Add(SetNamePG("Nhap", path[0], path[1]));
                input.Add("\t\t{");

                
                for (int i = 0; i < vari.Length; i += 2)
                {
                    string nhap1 = string.Format("\t\t\tConsole.WriteLine(" + "\"Nhap {0}: \");", vari[i]);
                    input.Add(nhap1);
                    string nhap2 = string.Format("\t\t\t{0} =", vari[i]);

                    if (vari[i + 1] == "R")
                    {
                    nhap2 += "float.Parse(Console.ReadLine());";
                    }
                    else if (vari[i + 1] == "Z")
                    {
                    nhap2 += "int.Parse(Console.ReadLine());";
                    }
                    else if (vari[i + 1] == "B")
                    {
                    nhap2 += "bool.Parse(Console.ReadLine());";
                    }
                    input.Add(nhap2);
                }
                input.Add("\t\t}");
                     
        }
        public void HamXuat(List<string> input, string namepath)
        {
            string[] path = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);

            string[] result_char = path[2].Split(new[] { ":" }, StringSplitOptions.None);


            input.Add(SetNamePG("Xuat", path[0], path[2]));
            input.Add("\t\t{");

                // nội dung hàm nhập
                for (int i = 0; i < result_char.Length; i += 2)
                {
                    string nhap = string.Format("\t\t\tConsole.WriteLine(" + "\"Ket qua la: \" + {0});", result_char[i]);
                input.Add(nhap);
                }
            input.Add("\t\t}");
            
                
           
        }
    }
    

}
