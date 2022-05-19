using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class InfoUser2
    {

        public string name;
        public string username;
        public string password;
        public string email;
        public string qualification;

        public void showMe()
        {
            Console.WriteLine("Working");
        }

        public InfoUser2(string nm, string usernm, string pwd, string mail, string qualifi)
        {
            name = nm;
            username = usernm;
            password = pwd;
            email = mail;
            qualification = qualifi;

        }
        public InfoUser2()
        {
            Console.Write("");
        }

        public void show()
        {
            //Console.WriteLine(name + username + password + email + qualification);
        }


        public int validate()
        {
            Console.WriteLine("");
            int forName(string v)
            {
                if (v == "null" || v == "")
                {
                    Console.WriteLine("Enter name:");
                    return 0;
                }
                else if (v.Length >= 3)
                //Regex.Match(v, "^[A-Z][a-zA-Z]*$").Success
                {
                    //Console.WriteLine(Regex.Match(v, "^[a-zA-Z]*$").Success);
                    if (Regex.Match(v, "^[a-zA-Z]*$").Success)
                    {
                        Console.Write("");
                        return 1;
                    }

                    else
                    {
                        Console.WriteLine("Name must not contain Special character and numbers");
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine("Name length must be 3 or more");
                    return 0;
                }
            }

            int forEmail(string email_id)
            {
                if (email_id == "null" || email_id == "")
                {
                    Console.WriteLine("Enter email id: ");
                    return 0;
                }
                else
                {

                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);

                    if (match.Success)
                    {
                        Console.Write("");
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Email is invalid");
                        return 0;
                    }
                }
            }

            int forUserName(string v)
            {
                if (v == "null" || v == "")
                {
                    Console.WriteLine("Enter username: ");
                    return 0;
                }
                else if (v.Length >= 3 && v.Length <= 16)
                //Regex.Match(v, "^[A-Z][a-zA-Z]*$").Success
                {
                    // "^[a-zA-Z0-9_]*$"
                    string regex = @"^([a-z0-9]+)_([a-z0-9]+)$";
                    //
                    Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9_]");

                    //Console.WriteLine(Regex.Match(v, "^[a-zA-Z][0-9]*$").Success);
                    if ((!Regex.IsMatch(v, regex)))
                    {
                        Console.WriteLine("--------Username Must Be AlphaNumeric + Underscrore-------- ");
                        //Console.Write("");
                        return 0;
                    }

                    else
                    {
                        //Console.WriteLine(v);
                        //Console.WriteLine("Username must not contain special character");
                        Console.Write("");
                        return 1;
                    }
                }
                else
                {
                    Console.WriteLine("Name length must be 3 or more");
                    return 0;
                }
            }

            int forPassword(string passwordValue)
            {
                //Console.WriteLine("password len: " + passwordValue.Length);
                if (passwordValue == "" || passwordValue == "null")
                {
                    Console.WriteLine("Enter password:");
                    return 0;
                    // passwordError = false;
                    // return false;
                }

                else if (passwordValue.Length >= 8 && passwordValue.Length <= 16)
                {
                    Console.Write("");
                    return 1;
                }
                else
                {
                    Console.WriteLine("Password length must be at least 8 digits and less then 16");
                    return 0;
                }
            }


            int count = 0;
            count += forName(name);
            count += forEmail(email);
            count += forUserName(username);
            count += forPassword(password);
            //count += forQualification(qualification);
            count += 1;
            //System.Threading.Thread.Sleep(5000);
            return count;
        }


        public int login(string email, string password)
        {
            Console.WriteLine("");
            int forEmail(string email_id)
            {
                if (email_id == "null" || email_id == "")
                {
                    Console.WriteLine("Enter email id: ");
                    return 0;
                }
                else
                {

                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);

                    if (match.Success)
                    {
                        Console.Write("");
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Email is invalid");
                        return 0;
                    }
                }
            }

            int forPassword(string passwordValue)
            {
                //Console.WriteLine("password len: " + passwordValue.Length);
                if (passwordValue == "" || passwordValue == "null")
                {
                    Console.WriteLine("Enter password:");
                    return 0;
                    // passwordError = false;
                    // return false;
                }

                else if (passwordValue.Length >= 8 && passwordValue.Length <= 16)
                {
                    Console.Write("");

                    return 1;
                    // passwordError = false;
                    // return false;
                }
                else
                {

                    Console.WriteLine("Password length must be at least 8 digits and less then 16");
                    return 0;
                }
            }
            int count = 0;
            count += forEmail(email);
            //Console.WriteLine(password.Length + " pass len");
            count += forPassword(password);
            return count;

        }


        public int update(string email, string password, string name)
        {
            Console.WriteLine("");
            int forEmail(string email_id)
            {
                if (email_id == "null" || email_id == "")
                {
                    Console.WriteLine("Enter email id: ");
                    return 0;
                }
                else
                {

                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);

                    if (match.Success)
                    {
                        Console.WriteLine("");
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Email is invalid");
                        return 0;
                    }
                }
            }

            int forPassword(string passwordValue)
            {
                //Console.WriteLine("password len: " + passwordValue.Length);
                if (passwordValue == "" || passwordValue == "null")
                {
                    Console.WriteLine("Enter password:");
                    return 0;
                    // passwordError = false;
                    // return false;
                }

                else if (passwordValue.Length >= 8 && passwordValue.Length <= 16)
                {
                    Console.Write("");
                    return 1;
                    // passwordError = false;
                    // return false;
                }
                else
                {
                    Console.WriteLine("password length must be at least 8 digits");
                    return 0;

                }
            }

            int forName(string v)
            {
                if (v == "null" || v == "")
                {
                    Console.WriteLine("Enter name");
                    return 0;
                }
                else if (v.Length >= 3)
                //Regex.Match(v, "^[A-Z][a-zA-Z]*$").Success
                {
                    //Console.WriteLine(Regex.Match(v, "^[a-zA-Z]*$").Success);
                    if (Regex.Match(v, "^[a-zA-Z]*$").Success)
                    {
                        Console.WriteLine("");
                        return 1;
                    }

                    else
                    {
                        Console.WriteLine("Name must not contain special character and numbers");
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine("Name length must be 3 or more");
                    return 0;
                }
            }


            int count = 0;
            count += forEmail(email);
            count += forPassword(password);
            count += forName(name);
            return count;

        }



    }

}
