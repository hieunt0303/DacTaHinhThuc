using System;
using System.Collections.Generic;
using System.Text;

namespace DacTa
{
    public class PostFunction : NameFunction
    {

        // hàm xử lý post 
        public void SetStatement(List<string> data_output, string postpath, string namepath)
        {

            string[] lines = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] vari = lines[2].Split(new[] { ":" }, StringSplitOptions.None);

            if (vari[1] == "R")
            {
                loai = "float ";
            }
            else if (vari[1] == "Z")
            {
                loai = "int ";
            }
            else if (vari[1] == "B")
            {
                loai = "bool ";
            }
            else if (vari[1] == "char*")
            {
                loai = "string ";
            }

            //tên hàm
            data_output.Add(SetNamePG("", namepath, loai));
            data_output.Add("\t\t{");
            //khởi tạo các biến kết quả
            if (vari[1] == "char*")
            {
                string CreateResult = string.Format("\t\t\t{0}{1} = null;", loai, vari[0]);
                data_output.Add(CreateResult);
            }
            else if (vari[1] == "R" || vari[1] == "Z")
            {
                string CreateResult = string.Format("\t\t\t{0}{1} = 0;", loai, vari[0]);
                data_output.Add(CreateResult);
            }
            else if (vari[1] == "B")
            {
                string CreateResult = string.Format("\t\t\t{0}{1} = true;", loai, vari[0]);
                data_output.Add(CreateResult);
            }
            //nội dung hàm post

                postpath = postpath.Replace("post", string.Empty).Replace(" ", string.Empty);
                string[] conditions = postpath.Split(new[] { "||" }, StringSplitOptions.None);
                for (int i = 0; i < conditions.Length; i++)
                {
                    conditions[i] = conditions[i].Replace("(", string.Empty).Replace(")", string.Empty);
                    if (conditions[i].Contains("&&") == true)
                    {
                        string[] conditions_result = conditions[i].Split(new[] { "&&" }, StringSplitOptions.None);
                        if (conditions_result.Length > 2)
                        {
                            for (int j = 1; j < conditions_result.Length; j++)
                            {
                                if (j == 1)
                                {
                                    conditions_result[j] = PreWrite(conditions_result[j]);
                                    statement = string.Format("\t\t\tif ({0} ", conditions_result[j]);
                                }
                                else if (j == conditions_result.Length - 1)
                                {
                                    conditions_result[j] = PreWrite(conditions_result[j]);
                                    statement += string.Format("&& {0})", conditions_result[j]);
                                }
                                else
                                {
                                    conditions_result[j] = PreWrite(conditions_result[j]);
                                    statement += string.Format("&& {0} ", conditions_result[j]);
                                }
                            }
                        }
                        else
                        {
                            conditions_result[1] = PreWrite(conditions_result[1]);
                            statement = string.Format("\t\t\tif ({0})", conditions_result[1]);
                        }
                        data_output.Add(statement);
                        string mainClause = string.Format("\t\t\t\t{0};", PreWriteTF(conditions_result[0]));
                        data_output.Add("\t\t\t{");
                        data_output.Add(mainClause);
                        data_output.Add("\t\t\t}");
                    }

                    else
                    {
                        string mainClause = string.Format("\t\t\t{0};", conditions[i]);
                        data_output.Add(mainClause);
                    }

                }
                string returnValue = string.Format("\t\t\treturn {0}; ", vari[0]);
                data_output.Add(returnValue);
                data_output.Add("\t\t}");
            
            
        }
        public string PreWrite(string beforePW)
        {
            string afterPW = beforePW;
            if (afterPW.Contains("=") &&
                 !afterPW.Contains(">=") &&
                 !afterPW.Contains("<=") &&
                 !afterPW.Contains("!=") &&
                 !afterPW.Contains("=="))
            {
                afterPW = afterPW.Replace("=", "==");
            }

            return afterPW;
        }

        public string PreWriteTF(string beforePW)
        {
            string afterPW = beforePW;
            if (afterPW.Contains("FALSE"))
            {
                afterPW = afterPW.Replace("FALSE", "false");
            }
            if (afterPW.Contains("TRUE"))
            {
                afterPW = afterPW.Replace("TRUE", "true");
            }
            return afterPW;
        }
    }
}
