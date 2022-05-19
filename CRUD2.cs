using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Calculator;
using System.Collections;

namespace Calculator
{
    public class CRUD2
    {
        public void LoginRecord(string email, string password)
        {
            using (NpgsqlConnection con = GetConnection())


            {
                con.Open();
                Console.Clear();
                // select  start        ('" + ulogin + "')";

                string sql = "SELECT * FROM public.users where email=('" + email + "') AND password =('" + password + "')";

                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                string val;
                string[] info = new string[6];
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    for (int x = 0; x <= 5; x++)
                    {

                        info[x] += reader[x].ToString();


                    }
                    //Console.WriteLine(info[0]);
                    //Console.WriteLine(info[1]);
                    //do whatever you like
                }
                reader.Close();
                if (info[1] == email && info[3] == password)
                {
                    Console.WriteLine("");
                    //string[] column = { "name", "email", "username", "password", "qualification", "sid" };
                    Console.WriteLine("----------------------  We found you  -------------------------\n");

                    Console.Write("---- ");
                    for (int x = 0; x <= 5; x++)
                    {

                        if (x != 4)
                        {

                            Console.Write(info[x] + " ---- ");
                        }


                    }
                    Console.WriteLine("\n-----------------  Do you want any changes (y/n)? --------------------\n");
                    char i = char.Parse(Console.ReadLine());
                    if (i == 'y')
                    {
                        //Console.Clear();
                        Console.WriteLine(" ----------------  Ok  --------------------");

                        Console.Write("Enter new name: ");
                        string name_new = Console.ReadLine();

                        Console.Write("Enter new password: ");
                        string password_new = Console.ReadLine();
                        // ignore email
                        string emaildummy = "sam@gmail.com";

                        InfoUser2 obj = new InfoUser2();
                        int j = obj.update(emaildummy, password_new, name_new);

                        if (j == 3)
                        {

                            string query = @"insert into public.update(name,email,password)values(('" + name_new + "'),('" + email + "'),('" + password_new + "'))";
                            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                            int v = cmd.ExecuteNonQuery();
                            int n = v;
                            if (n == 1)
                            {
                                Console.WriteLine("Request is sended to admin");
                                System.Threading.Thread.Sleep(2000);
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Rejected");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("UserNotFound");
                    System.Threading.Thread.Sleep(2000);
                }
                Console.WriteLine("");
                // close the query
                reader.Close();
                // select


            }
        }
        public void UserDemands()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();

                string sql = "SELECT * FROM public.update";

                NpgsqlCommand command = new NpgsqlCommand(sql, con);

                NpgsqlDataReader dr = command.ExecuteReader();
                //dr.Close();
                // Output rows
                // Dynamic Array
                ArrayList array = new ArrayList();

                //string[] emailIds = new string[10];
                int i = 0;
                while (dr.Read())
                {
                    Console.WriteLine("------------- Following are the user demanding there info updation ----------------");

                    array.Add(Convert.ToString(dr[1]));
                    //emailIds[i] = Convert.ToString(dr[1]);
                    i += 1;

                    Console.Write("---- name:{0} ---- \temail:{1} ---- \tpwd:{2} ----\n", dr[0], dr[1], dr[2]);
                    Console.WriteLine("Enter (y/n) admin ");
                    char flag = char.Parse(Console.ReadLine());
                    if (flag == 'y')
                    {
                        string update = "UPDATE users SET name = '" + dr[0] + "', password = '" + dr[2] + "'  where email=('" + dr[1] + "')";
                        // ------------------------  Updating  -----------------------  //
                        using (NpgsqlConnection con2 = GetConnection())
                        {
                            con2.Open();
                            NpgsqlCommand cmd = new NpgsqlCommand(update, con2);
                            //NpgsqlDataReader reader2 = cmd.ExecuteReader();

                            int v = cmd.ExecuteNonQuery();
                            int n = v;
                            if (n == 1)
                            {
                                Console.WriteLine("user name: {0} is updated", dr[0]);
                            }

                        }

                    }

                }
                dr.Close();
                // here
                // --------------------------   Deletion ------------------------------------ //
                //Console.WriteLine(emailIds[0] + " here");
                //Console.WriteLine(array.Count + ": len");
                for (int j = 0; j < array.Count; j++)
                {
                    //Console.Write("yew" + array[0]);
                    //array.Remove(sr);

                    using (NpgsqlConnection con3 = GetConnection())
                    {
                        con3.Open();
                        string delsql = "DELETE FROM public.update WHERE email='" + array[j] + "'";

                        NpgsqlCommand del = new NpgsqlCommand(delsql, con);
                        int k = del.ExecuteNonQuery(); ;
                        if (k == 1)
                        {
                            Console.WriteLine("");
                        }
                    }
                }

            }

        }
        public void Delete()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                Console.Write("Enter person email to delete that person: ");
                string email = Console.ReadLine();
                //string sql = "SELECT * FROM public.users ";
                string sql = "DELETE FROM users WHERE email='" + email + "'";

                //NpgsqlCommand command = new NpgsqlCommand(sql, con);
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                int v = cmd.ExecuteNonQuery();
                int n = v;
                if (n == 1)
                {
                    Console.WriteLine("Record deleted");
                }
                //reader.Close();

            }

        }
        public void Update()
        {
            using (NpgsqlConnection con = GetConnection())

            {
                Console.Clear();
                con.Open();
                Console.Write("--------------------------- Update ------------------------------\n");

                Console.WriteLine("Enter new name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter new password: ");
                string password = Console.ReadLine();

                Console.Write("Person email : ");
                string email = Console.ReadLine();

                InfoUser2 val = new InfoUser2();
                int i = val.update(email, password, name);

                if (i == 3)
                {
                    string sql = "UPDATE users SET name = '" + name + "', password = '" + password + "'  where email=('" + email + "')";

                    NpgsqlCommand command = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine("Updation is done");
                    }
                    reader.Close();
                }

            }

        }
        public void ShowAll()
        {

            using (NpgsqlConnection con = GetConnection())


            {
                con.Open();
                // select  start        ('" + ulogin + "')";
                string sql = "SELECT * FROM public.users";

                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                string val;
                string[] info = new string[6];
                NpgsqlDataReader reader = command.ExecuteReader();
                reader.Close();
                // Define a query
                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                Console.WriteLine("-------- name -------- email -------- username ---------- password --------- sid --------\n");
                while (dr.Read())
                {
                    Console.Write("---- {0} ---- \t{1} ---- \t{2} ---- \t{3} ---- \t{5} ----\n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }



                // close the query

                // select


            }

        }
        public void InsertRecord(string email, string name, string username, string password, string qualification)
        {

            using (NpgsqlConnection con = GetConnection())


            {
                con.Open();
                // select  start        ('" + ulogin + "')";

                string sql = "SELECT * FROM public.users where email=('" + email + "')";

                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                string val;
                string[] info = new string[6];
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    for (int x = 0; x <= 5; x++)
                    {

                        info[x] += reader[x].ToString();


                    }
                    //Console.WriteLine(info[0]);
                    //Console.WriteLine(info[1]);
                    //do whatever you like
                }
                reader.Close();
                if (info[1] == email)
                {
                    Console.WriteLine("Email already exist ");
                    System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    string query = @"insert into public.users(name,email,username,password,qualification)values(('" + name + "'),('" + email + "'), ('" + username + "'),('" + password + "'),('" + qualification + "'))";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                    int v = cmd.ExecuteNonQuery();
                    int n = v;
                    if (n == 1)
                    {
                        Console.WriteLine("Record inserted");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                // close the query

                // select


            }

        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

    }

}
