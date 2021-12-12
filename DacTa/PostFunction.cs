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
            else if (vari[1] == "N")
            {
                loai = "int ";
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
            if (lines[0] != "Ham")
            {
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
                                    conditions_result[j] = PreWrite(conditions_result[j],0);
                                    statement = string.Format("\t\t\tif ({0} ", conditions_result[j]);
                                }
                                else if (j == conditions_result.Length - 1)
                                {
                                    conditions_result[j] = PreWrite(conditions_result[j],0);
                                    statement += string.Format("&& {0})", conditions_result[j]);
                                }
                                else
                                {
                                    conditions_result[j] = PreWrite(conditions_result[j],0);
                                    statement += string.Format("&& {0} ", conditions_result[j]);
                                }
                            }
                        }
                        else
                        {
                            conditions_result[1] = PreWrite(conditions_result[1],0);
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
            else
            {
                int check=0; // kiểm tra VM TT
                string statementOut = ""; // trả True Flase ngoài vòng for
                string conVari;  // i
                string conVari2; // j
                string[] getCondition = postpath.Split(new[] { "=(" }, StringSplitOptions.None);     //tách lấy post khỏi kq=
                string condition1 = getCondition[1].Substring(0, getCondition[1].Length - 1);        // lấy phần post chính 
                string condition2 = condition1.Replace("..", "_");                                   //thay .. bằng "_" để cắt bằng "."         
                string[] conditionVari = condition2.Split(new[] { "." }, StringSplitOptions.None);   // tách các phần điều kiện
                if (conditionVari.Length > 2)                           // xét có i và j
                {
                    for (int i = 0; i < conditionVari.Length; i++)   // xử lý từng phần điều kiện i j 
                    {
                        
                            if (conditionVari[i].Contains("TH") == true)   // xác định phần i và j bằng  TH
                            {
                            if (conditionVari[i].Contains("VM") == true) check = 1; // kiểm tra có VM hay ko
                               if (i == 0)
                               {
                                
                                string[] varipath = conditionVari[i].Split(new[] { "{", "_", "}" }, StringSplitOptions.None); // tách i và giới hạn
                                conVari = varipath[0].Substring(2, varipath[0].Length - 4); // i

                                string[] checkVari = conditionVari[i + 1].Split(new[] { ".." }, StringSplitOptions.None); // cắt khoảng giới hạn

                                string statement1 = string.Format("\t\t\tfor(int {0} = {1}; {0} < {2} ;{0}++)", conVari, varipath[1], varipath[2]);
                                data_output.Add(statement1);
                                data_output.Add("\t\t\t{");
                               }
                               else
                               {
                                string[] varipath = conditionVari[i].Split(new[] { "{", "_", "}" }, StringSplitOptions.None); 
                                conVari = varipath[0].Substring(2, varipath[0].Length - 4); 

                                string[] checkVari = conditionVari[i + 1].Split(new[] { ".." }, StringSplitOptions.None); 

                                string statement1 = string.Format("\t\t\t\tfor(int {0} = {1}; {0} < {2} ;{0}++)", conVari, varipath[1], varipath[2]);
                                data_output.Add(statement1);
                                data_output.Add("\t\t\t\t{");
                               }
                                                               
                            }
                            else if (conditionVari[i].Contains("a") == true)   // xác định xử lý phần điều kiện true false
                            {
                            if (check == 1)         // có VM
                            {
                                string statement = conditionVari[i].Replace("(", "[").Replace(")", "]");
                                statement = PreWrite(statement, 1);
                                statement = string.Format("\t\t\t\t\tif({0})", statement);
                                string statement2 = string.Format("\t\t\t\t\t{0} =false ;", vari[0]);
                                statementOut = string.Format("\t\t\t\t{0} =true ;", vari[0]);
                                data_output.Add(statement);
                                data_output.Add(statement2);
                                data_output.Add("\t\t\t\t}");
                                
                            }
                            else
                            {
                                string statement = conditionVari[i].Replace("(", "[").Replace(")", "]");
                                statement = string.Format("\t\t\t\t\tif({0})", statement);
                                string statement2 = string.Format("\t\t\t\t\t{0} =true ;", vari[0]);
                                statementOut = string.Format("\t\t\t{0} =false ;", vari[0]);
                                data_output.Add(statement);
                                data_output.Add(statement2);
                                data_output.Add("\t\t\t\t}");
                                
                            }
                            
                            }
                       


                    }
                    data_output.Add("\t\t\t}");
                    data_output.Add(statementOut);
                    string returnValue = string.Format("\t\t\treturn {0}; ", vari[0]);
                    data_output.Add(returnValue);
                    data_output.Add("\t\t}");

                }
                else
                {
                    for (int i = 0; i < conditionVari.Length; i++)
                    {
                        string[] vartpath = conditionVari[i].Split(new[] { "{","}" }, StringSplitOptions.None); // tach i va gioi ham 
                        for(int j = 0; j < vartpath.Length; j++)
                        {
                            if (vartpath[j].Contains("TH") == true)
                            {
                                string[] checkVari = vartpath[j + 1].Split(new[] { "_" }, StringSplitOptions.None);
                                conVari = vartpath[j].Substring(2, vartpath.Length - 2); // lấy i
                                string statement1 = string.Format("\t\t\tfor(int {0} = {1}; {0} < {2} ;{0}++)", conVari, checkVari[0], checkVari[1]);
                                data_output.Add(statement1);
                                data_output.Add("\t\t\t{");
                                string statement2 = conditionVari[i + 1]; // dieu kien
                                if (vartpath[i].Contains("VM") == true)
                                {
                                    statement2 = PreWrite(statement2, 1);
                                    statement2 = statement2.Replace("(", "[").Replace(")", "]");
                                    string statement3 = string.Format("\t\t\tif({0})", statement2);
                                    string returnValue1 = string.Format("\t\t\t{0}= false; ", vari[0]);
                                    data_output.Add(statement3);
                                    data_output.Add(returnValue1);
                                }
                                else if (vartpath[j].Contains("TT") == true)
                                {
                                    statement2 = statement2.Replace("(", "[").Replace(")", "]");
                                    string statement3 = string.Format("\t\t\tif({0}) )", statement2);
                                    string returnValue1 = string.Format("\t\t\t{0}= true; ", vari[0]);
                                    data_output.Add(statement3);
                                    data_output.Add(returnValue1);
                                }
                                data_output.Add("\t\t\t}");
                                string returnValue = string.Format("\t\t\treturn {0}; ", vari[0]);
                                data_output.Add(returnValue);
                                data_output.Add("\t\t}");
                            }
                        }
                        
                    }
                }
                
            }
            
            
        }
        public string PreWrite(string beforePW,int check)
        {
            string afterPW = beforePW;
            if (check == 0)
            {
                
                if (afterPW.Contains("=") &&
                     !afterPW.Contains(">=") &&
                     !afterPW.Contains("<=") &&
                     !afterPW.Contains("!=") &&
                     !afterPW.Contains("=="))
                {
                    afterPW = afterPW.Replace("=", "==");
                }
            }
            else                                                   // xét để đổi ngược dấu
            {
                if(afterPW.Contains("<="))
                    afterPW = afterPW.Replace("<=", ">");
                else if (afterPW.Contains(">="))
                    afterPW = afterPW.Replace(">=", "<");
                else if (afterPW.Contains(">"))
                    afterPW = afterPW.Replace(">", "<=");
                else if (afterPW.Contains("<"))
                    afterPW = afterPW.Replace("<", ">=");
                else if (afterPW.Contains("="))
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
