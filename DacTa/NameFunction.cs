using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace DacTa
{
    public class NameFunction
    {
        public string NameFunc;
        public string txtOut;
        public string loai;
        public string[] stringOut;
        public string namePG;
        public string namepath;
        public string statement;

       
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
           
                input.Add(SetNamePG("Nhap", namepath, path[1]));
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


            input.Add(SetNamePG("Xuat", namepath, path[2]));
            input.Add("\t\t{");

                // nội dung hàm nhập
                for (int i = 0; i < result_char.Length; i += 2)
                {
                    string nhap = string.Format("\t\t\tConsole.WriteLine(" + "\"Ket qua la: \" + {0});", result_char[i]);
                input.Add(nhap);
                }
            input.Add("\t\t}");           
                
        }
        // hàm xây dựng main
        public void SetMain(List<string> input, string namepath)
        {
            input.Add("\t\tpublic static void Main(string[] args)");
            input.Add("\t\t{");
            

            string[] lines = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] vari1 = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
            for (int i = 0; i < vari1.Length; i += 2)
            {

                if (vari1[i + 1] == "R")
                {
                    loai = "float ";
                }
                else if (vari1[i + 1] == "Z")
                {
                    loai = "int ";
                }
                else if (vari1[i + 1] == "B")
                {
                    loai = "bool ";
                }
                else if (vari1[i + 1] == "char*")
                {
                    loai = "string ";
                }
                string CreateResult = string.Format("\t\t\t{0}{1} = 0;", loai, vari1[i]);
                input.Add(CreateResult);
            }
            string[] vari2 = lines[2].Split(new[] { ":" }, StringSplitOptions.None);
            for (int i = 0; i < vari2.Length; i += 2)
            {

                if (vari2[i + 1] == "R")
                {
                    loai = "float ";
                    string CreateResult = string.Format("\t\t\t{0}{1} = 0;", loai, "kq");
                    input.Add(CreateResult);
                }
                else if (vari2[i + 1] == "Z")
                {
                    loai = "int ";
                    string CreateResult = string.Format("\t\t\t{0}{1} = 0;", loai, "kq");
                    input.Add(CreateResult);
                }
                else if (vari2[i + 1] == "B")
                {
                    loai = "bool ";
                    string CreateResult = string.Format("\t\t\t{0}{1} = true;", loai, "kq");
                    input.Add(CreateResult);
                }
                else if (vari2[i + 1] == "char*")
                {
                    loai = "string ";
                    string CreateResult = string.Format("\t\t\t{0}{1} = null;", loai, "kq");
                    input.Add(CreateResult);
                }

            }
            input.Add("\t\t\tProgram p = new Program();");

            //khoi tao ham Nhap trong main
            string functionname = string.Format("\t\t\tp.Nhap{0}(", lines[0]);
            if (vari1.Length > 2)
            {
                for (int i = 0; i < vari1.Length; i += 2)
                {
                    if (i == 0)
                    {
                        string varName = string.Format("ref {0}, ", vari1[i]);
                        functionname += varName;
                    }
                    else
                    {
                        string varName = string.Format("ref {0}", vari1[i]);
                        functionname += varName;
                    }
                }
            }
            else
            {
                string varName = string.Format("ref {0}", vari1[0]);
                functionname += varName;
            }

            functionname += ");";
            input.Add(functionname);
            //Kiem tra dieu kien
            string funcCondition = string.Format("\t\t\tif(p.KiemTra{0}(", lines[0]);
            if (vari1.Length > 2)
            {
                for (int i = 0; i < vari1.Length; i += 2)
                {
                    if (i == 0)
                    {
                        string varName = string.Format("{0}, ", vari1[i]);
                        funcCondition += varName;
                    }
                    else
                    {
                        string varName = string.Format("{0}", vari1[i]);
                        funcCondition += varName;
                    }
                }
            }
            else
            {
                string varName = string.Format("{0}", vari1[0]);
                funcCondition += varName;
            }
            funcCondition += ")==1)";
            input.Add(funcCondition);
            input.Add("\t\t\t{");

            string funcCheck = string.Format("\t\t\t\t{1} = p.{0}(", lines[0], "kq");
            if (vari1.Length > 2)
            {
                for (int i = 0; i < vari1.Length; i += 2)
                {
                    if (i == 0)
                    {
                        string varName = string.Format("{0}, ", vari1[i]);
                        funcCheck += varName;
                    }
                    else
                    {
                        string varName = string.Format("{0}", vari1[i]);
                        funcCheck += varName;
                    }
                }
            }
            else
            {
                string varName = string.Format("{0}", vari1[0]);
                funcCheck += varName;
            }
            funcCheck += ");";
            input.Add(funcCheck);

            string funcOut = string.Format("\t\t\t\tp.Xuat{0}(", lines[0]);
            string varName1 = string.Format("{0}", "kq");
            funcOut += varName1;
            funcOut += ");";
            input.Add(funcOut);
            input.Add("\t\t\t}");
            input.Add("\t\t\telse");
            input.Add("\t\t\t\tConsole.WriteLine(\"tham so sai ,nhap lai \");");
            input.Add("\t\t\tConsole.ReadLine();");
            input.Add("\t\t}");
        }
    }
    

}
