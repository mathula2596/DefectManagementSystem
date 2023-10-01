using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDefect.Models
{
    public class LoginDataAccessLayer
    {
        string con_string = "Data Source=MATHULA;Initial Catalog=defect;Integrated Security=True";
        public LoginModel Find(string username, string password)
        {
            LoginModel objModel = new LoginModel();
            UsersModel usersModel = new UsersModel();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                
                string query = "select * from login inner join users on users.id=login.id where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
               
                con.Open();
                //ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // ItemModdel tempModel = new ItemModdel();
                    objModel.id = int.Parse(rdr["id"].ToString());
                    objModel.username = rdr["username"].ToString();
                    objModel.password = rdr["password"].ToString();
                    objModel.usertype = rdr["usertype"].ToString();
                    objModel.firstname = rdr["firstname"].ToString();
                    //objModel.Add(tempModel);

                }
                //con.Close();
            }
            return objModel;

        }
       
        public void CreateLogin(LoginModel loginModel)
        {
        
           

            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "INSERT INTO login ([username],[password],[usertype]) VALUES ( @username , @password,@usertype)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", loginModel.username);
                cmd.Parameters.AddWithValue("@password", loginModel.password);
                cmd.Parameters.AddWithValue("@usertype", loginModel.usertype);


                cmd.ExecuteNonQuery();
                con.Close();

                //return result;

            }
        }
        public void FindUsername(string username, string password)
        {
            UsersModel objModel = new UsersModel();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(con_string))
            {

                string query = "select * from login where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                //ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {

                }
                else
                {
                    while(rdr.Read())
                    {
                        break;
                    }
                }
                //con.Close();
            }
          //  return objModel;

        }
        public void Forgot(LoginModel loginModel)
        {

            FindUsername(loginModel.username,loginModel.password);
            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "UPDATE login SET [username]=@username ,[password]=@newpassword where [username]=@username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", loginModel.username);
                cmd.Parameters.AddWithValue("@password", loginModel.password);
                cmd.Parameters.AddWithValue("@newpassword", loginModel.newpassword);


                cmd.ExecuteNonQuery();
                con.Close();

                //return result;

            }
        }
    }
}
