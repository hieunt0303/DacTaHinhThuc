using System;
using System.Collections.Generic;
using System.Text;

namespace DacTa
{
    public class pyNameFunction
    {
        public string NameFunc;
        public string txtOut;
        public string loai;
        public string[] stringOut;
        public string namePG;
        public string namepath;
        public string statement;


        // hàm chung output tên hàm 
        public string SetNamePG(string NameFunc, string namePath, string loai)
        {
            if (NameFunc == "Xuat")
            {
                string[] lines = namePath.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] vari = lines[2].Split(new[] { ":" }, StringSplitOptions.None);
                string funname = string.Format("def {1}{0}(", lines[0], NameFunc);
                for (int i = 0; i < vari.Length; i += 2)
                {
                    string varName = string.Format("{0}", vari[i]);
                    funname += varName;
                }
                funname += "):";
                return funname;
            }
            else if (NameFunc == "")
            {
                string[] lines = namePath.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] vari = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                string funname = string.Format("def {1}{0}(", lines[0], NameFunc);
                for (int i = 0; i < vari.Length; i += 2)
                {
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
                funname += "):";
                return funname;
            }
            else if (NameFunc == "KiemTra")
            {
                string[] lines = namePath.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] vari = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                string funname = string.Format("def {1}{0}(", lines[0], NameFunc);
                for (int i = 0; i < vari.Length; i += 2)
                {
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
                funname += "):";
                return funname;
            }
            // Nhap
            else
            {
                string[] lines = namePath.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] vari = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                
                string funname = string.Format("def {1}{0}(", lines[0], NameFunc);

              
                    for (int i = 0; i < vari.Length; i += 2)
                    {
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
                
                funname += "):";
                return funname;
            }
        }

        public void HamNhap(List<string> input, string namepath)
        {
            string[] path = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] vari = path[1].Split(new[] { ":", "," }, StringSplitOptions.None);

            input.Add(SetNamePG("Nhap", namepath, path[1]));
            
            if (namepath.Split(new[] { "(", ")" }, StringSplitOptions.None)[0] == "Ham")
            {
                string nhap2 = "\tn = int(input('Nhap n: '))\n";
                nhap2 += "\tfor i in range(n):\n";
                nhap2 += "\t\ta.append(input('Nhap so thu %d: ' % (i+1)))\n";
                input.Add(nhap2);
            }
            else
            {
                for (int i = 0; i < vari.Length; i += 2)
                {
                    string nhap2 = string.Format("\t{0} =", vari[i]);

                    if (vari[i + 1] == "R")
                    {
                        nhap2 += "float(input('Nhap " + vari[i] + ": '))";
                    }
                    else if (vari[i + 1] == "Z")
                    {
                        nhap2 += "int(input('Nhap " + vari[i] + ": '))";
                    }
                    else if (vari[i + 1] == "B")
                    {
                        nhap2 += "bool(input('Nhap " + vari[i] + ": '))";
                    }
                    input.Add(nhap2);
                }
                string returnInput = "\treturn ";
                for (int i = 0; i < vari.Length; i += 2)
                {
                    returnInput += vari[i];
                    if (i < vari.Length - 2)
                        returnInput += ",";
                }
                input.Add(returnInput);
            }
        }
        public void HamXuat(List<string> input, string namepath)
        {
            string[] path = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);

            string[] result_char = path[2].Split(new[] { ":" }, StringSplitOptions.None);


            input.Add(SetNamePG("Xuat", namepath, path[2]));

            // nội dung hàm nhập
            for (int i = 0; i < result_char.Length; i += 2)
            {
                string nhap = "\tprint('Ket qua la: ' + str(" + result_char[i] + "))";
                input.Add(nhap);
            }

        }
        // hàm xây dựng main
        public void SetMain(List<string> input, string namepath)
        {
            string[] lines = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] vari1 = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
            if (lines[0] == "Ham")
            {
                input.Add("a=[]\nn=0\n");
            }
            else
            {
                for (int i = 0; i < vari1.Length; i += 2)
                {
                    string CreateResult = string.Format("{0}= 0", vari1[i]);
                    input.Add(CreateResult);
                }
            }
            string[] vari2 = lines[2].Split(new[] { ":" }, StringSplitOptions.None);
            for (int i = 0; i < vari2.Length; i += 2)
            {

                if (vari2[i + 1] == "R")
                {
                    loai = "float ";
                    string CreateResult = string.Format("{0} = 0", "kq");
                    input.Add(CreateResult);
                }
                else if (vari2[i + 1] == "Z")
                {
                    loai = "int ";
                    string CreateResult = string.Format("{0} = 0", "kq");
                    input.Add(CreateResult);
                }
                else if (vari2[i + 1] == "B")
                {
                    loai = "bool ";
                    string CreateResult = string.Format("{0} = True", "kq");
                    input.Add(CreateResult);
                }
                else if (vari2[i + 1] == "char*")
                {
                    loai = "string ";
                    string CreateResult = string.Format("{0} = ''", "kq");
                    input.Add(CreateResult);
                }
            }
           
            string arrInput = "";
            for (int i = 0; i < vari1.Length; i += 2)
            {
                arrInput += vari1[i];
                if (i < vari1.Length - 2)
                    arrInput += ",";
            }
            string functionname = "";
            if (lines[0] == "Ham")
            {
                functionname = string.Format("Nhap{0}(", lines[0]);
            }
            else
            {
                //khoi tao ham Nhap trong main
                functionname = string.Format("{0} = Nhap{1}(", arrInput, lines[0]);
            }

            if (vari1.Length > 2)
            {
                for (int i = 0; i < vari1.Length; i += 2)
                {
                    if (i == 0)
                    {
                        string varName = string.Format("{0}, ", vari1[i]);
                        functionname += varName;
                    }
                    else
                    {
                        string varName = string.Format("{0}", vari1[i]);
                        functionname += varName;
                    }
                }
            }
            else
            {
                string varName = string.Format("{0}", vari1[0]);
                functionname += varName;
            }

            functionname += ")";
            input.Add(functionname);
            //Kiem tra dieu kien
            string funcCondition = string.Format("if KiemTra{0}(", lines[0]);
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
            funcCondition += ")==1 :";
            input.Add(funcCondition);

            string funcCheck = string.Format("\t{1} = {0}(", lines[0], "kq");
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
            funcCheck += ")";
            input.Add(funcCheck);

            string funcOut = string.Format("\tXuat{0}(", lines[0]);
            string varName1 = string.Format("{0}", "kq");
            funcOut += varName1;
            funcOut += ")";
            input.Add(funcOut);
            input.Add("else :");
            input.Add("\tprint('tham so sai ,nhap lai')");
        }
    }
}
