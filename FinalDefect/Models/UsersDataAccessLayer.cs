using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDefect.Models
{
    public class UsersDataAccessLayer
    {
        string con_string = "Data Source=MATHULA;Initial Catalog=defect;Integrated Security=True";


        public IEnumerable<UsersModel> Refresh()
        {
            List<UsersModel> objModel = new List<UsersModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "select * from users inner join login on login.id=users.id";
                SqlCommand cmd = new SqlCommand(query, con);
                ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UsersModel tempModel = new UsersModel();
                    tempModel.id = int.Parse(rdr["id"].ToString());
                    tempModel.firstname = rdr["firstname"].ToString();
                    tempModel.lastname = rdr["lastname"].ToString();
                    tempModel.phone = int.Parse(rdr["phone"].ToString());
                    tempModel.email = rdr["email"].ToString();
                    tempModel.address = rdr["address"].ToString();
                    tempModel.status = rdr["status"].ToString();
                    objModel.Add(tempModel);
                }
                con.Close();
            }
            return objModel;

        }
        public IEnumerable<UsersModel> RefreshTester()
        {
            List<UsersModel> objModel = new List<UsersModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "select * from users inner join login on login.id=users.id where login.usertype='Developer'";
                SqlCommand cmd = new SqlCommand(query, con);
                ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UsersModel tempModel = new UsersModel();
                    tempModel.id = int.Parse(rdr["id"].ToString());
                    tempModel.firstname = rdr["firstname"].ToString();
                    tempModel.lastname = rdr["lastname"].ToString();
                    tempModel.phone = int.Parse(rdr["phone"].ToString());
                    tempModel.email = rdr["email"].ToString();
                    tempModel.address = rdr["address"].ToString();
                    tempModel.status = rdr["status"].ToString();
                    objModel.Add(tempModel);
                }
                con.Close();
            }
            return objModel;

        }
        public IEnumerable<UsersModel> RefreshManager()
        {
            List<UsersModel> objModel = new List<UsersModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "select * from users inner join login on login.id=users.id where login.usertype='Developer' or login.usertype='Tester'";
                SqlCommand cmd = new SqlCommand(query, con);
                ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UsersModel tempModel = new UsersModel();
                    tempModel.id = int.Parse(rdr["id"].ToString());
                    tempModel.firstname = rdr["firstname"].ToString();
                    tempModel.lastname = rdr["lastname"].ToString();
                    tempModel.phone = int.Parse(rdr["phone"].ToString());
                    tempModel.email = rdr["email"].ToString();
                    tempModel.address = rdr["address"].ToString();
                    tempModel.status = rdr["status"].ToString();
                    objModel.Add(tempModel);
                }
                con.Close();
            }
            return objModel;

        }
        public IEnumerable<UsersModel> RefreshDeveloper()
        {
            List<UsersModel> objModel = new List<UsersModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "select * from users inner join login on login.id=users.id where  login.usertype='Tester'";
                SqlCommand cmd = new SqlCommand(query, con);
                ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UsersModel tempModel = new UsersModel();
                    tempModel.id = int.Parse(rdr["id"].ToString());
                    tempModel.firstname = rdr["firstname"].ToString();
                    tempModel.lastname = rdr["lastname"].ToString();
                    tempModel.phone = int.Parse(rdr["phone"].ToString());
                    tempModel.email = rdr["email"].ToString();
                    tempModel.address = rdr["address"].ToString();
                    tempModel.status = rdr["status"].ToString();
                    objModel.Add(tempModel);
                }
                con.Close();
            }
            return objModel;

        }
        public UsersModel FindUser(int id)
         {
            UsersModel objModel = new UsersModel();
             DataTable dt = new DataTable();

             using (SqlConnection con = new SqlConnection(con_string))
             {
                
                 string query = "select * from users inner join login on login.id=users.id where users.id=@id";
                 SqlCommand cmd = new SqlCommand(query, con);
                 cmd.Parameters.AddWithValue("@id", id);
                 con.Open();
                 //ConnectionState stat = con.State;
                 SqlDataReader rdr = cmd.ExecuteReader();

                 while (rdr.Read())
                 {
                     // ItemModdel tempModel = new ItemModdel();
                     objModel.id = int.Parse(rdr["id"].ToString());
                     objModel.firstname = rdr["firstname"].ToString();
                     objModel.lastname = rdr["lastname"].ToString();
                     objModel.phone = int.Parse(rdr["phone"].ToString());
                     objModel.email = rdr["email"].ToString();
                     objModel.address = rdr["address"].ToString();
                    objModel.status = rdr["status"].ToString();
                    objModel.username = rdr["username"].ToString();
                     objModel.password = rdr["password"].ToString();
                     objModel.usertype = rdr["usertype"].ToString();
                    //objModel.Add(tempModel);
                }
                 //con.Close();
             }
             return objModel;

         }

        public UsersModel FindUserTester(int id)
        {
            UsersModel objModel = new UsersModel();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(con_string))
            {

                string query = "select * from users inner join login on login.id=users.id where users.id=@id and login.usertype='Developer'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                //ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // ItemModdel tempModel = new ItemModdel();
                    objModel.id = int.Parse(rdr["id"].ToString());
                    objModel.firstname = rdr["firstname"].ToString();
                    objModel.lastname = rdr["lastname"].ToString();
                    objModel.phone = int.Parse(rdr["phone"].ToString());
                    objModel.email = rdr["email"].ToString();
                    objModel.address = rdr["address"].ToString();
                    objModel.status = rdr["status"].ToString();
                    objModel.username = rdr["username"].ToString();
                    objModel.password = rdr["password"].ToString();
                    objModel.usertype = rdr["usertype"].ToString();
                    //objModel.Add(tempModel);
                }
                //con.Close();
            }
            return objModel;

        }

        public UsersModel FindUserManager(int id)
        {
            UsersModel objModel = new UsersModel();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(con_string))
            {

                string query = "select * from users inner join login on login.id=users.id where users.id=@id and login.usertype='Developer' or login.usertype='Tester'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                //ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // ItemModdel tempModel = new ItemModdel();
                    objModel.id = int.Parse(rdr["id"].ToString());
                    objModel.firstname = rdr["firstname"].ToString();
                    objModel.lastname = rdr["lastname"].ToString();
                    objModel.phone = int.Parse(rdr["phone"].ToString());
                    objModel.email = rdr["email"].ToString();
                    objModel.address = rdr["address"].ToString();
                    objModel.status = rdr["status"].ToString();
                    objModel.username = rdr["username"].ToString();
                    objModel.password = rdr["password"].ToString();
                    objModel.usertype = rdr["usertype"].ToString();
                    //objModel.Add(tempModel);
                }
                //con.Close();
            }
            return objModel;

        }

        public UsersModel FindUserDeveloper(int id)
        {
            UsersModel objModel = new UsersModel();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(con_string))
            {

                string query = "select * from users inner join login on login.id=users.id where users.id=@id and login.usertype='Tester'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                //ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // ItemModdel tempModel = new ItemModdel();
                    objModel.id = int.Parse(rdr["id"].ToString());
                    objModel.firstname = rdr["firstname"].ToString();
                    objModel.lastname = rdr["lastname"].ToString();
                    objModel.phone = int.Parse(rdr["phone"].ToString());
                    objModel.email = rdr["email"].ToString();
                    objModel.address = rdr["address"].ToString();
                    objModel.status = rdr["status"].ToString();
                    objModel.username = rdr["username"].ToString();
                    objModel.password = rdr["password"].ToString();
                    objModel.usertype = rdr["usertype"].ToString();
                    //objModel.Add(tempModel);
                }
                //con.Close();
            }
            return objModel;

        }
        /*  public LoginModel FindLogin(int id)
          {
              LoginModel objModel = new LoginModel();
              DataTable dt = new DataTable();

              using (SqlConnection con = new SqlConnection(con_string))
              {

                  string query = "select * from login where id=@id";
                  SqlCommand cmd = new SqlCommand(query, con);
                  cmd.Parameters.AddWithValue("@id", id);
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

                      //objModel.Add(tempModel);
                  }
                  //con.Close();
              }
              return objModel;

          }*/
        public void CreateUser(UsersModel usersModel)
         {


             using (SqlConnection con = new SqlConnection(con_string))
             {
                
                 string query = "INSERT INTO users ([firstname],[lastname],[phone],[email],[address]) VALUES ( @firstname , @lastname,@phone,@email,@address )";
                 con.Open();
                 SqlCommand cmd = new SqlCommand(query, con);

                 cmd.Parameters.AddWithValue("@firstname", usersModel.firstname);
                cmd.Parameters.AddWithValue("@lastname", usersModel.lastname);
                cmd.Parameters.AddWithValue("@phone", usersModel.phone);
                cmd.Parameters.AddWithValue("@email", usersModel.email);
                cmd.Parameters.AddWithValue("@address", usersModel.address);
               
                 cmd.ExecuteNonQuery();
                 con.Close();

                 //return result;

             }
         }
        public void CreateLogin(RegisterModel registerModel)
        {


            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "INSERT INTO login([username],[password],[usertype])VALUES(@username , @password,@usertype)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", registerModel.username);
                cmd.Parameters.AddWithValue("@password", registerModel.password);
                cmd.Parameters.AddWithValue("@usertype", registerModel.usertype);
              

                cmd.ExecuteNonQuery();
                con.Close();

                //return result;

            }
        }



          public void EditUser(UsersModel userModel)
          {


              using (SqlConnection con = new SqlConnection(con_string))
              {
                  con.Open();
                  string query = "UPDATE users SET [firstname]=@firstname ,[lastname]=@lastname,[phone]=@phone,[email]=@email, [address]=@address,[status]=@status where [id]=@id";
                  SqlCommand cmd = new SqlCommand(query, con);
                  cmd.Parameters.AddWithValue("@id", userModel.id);
                  cmd.Parameters.AddWithValue("@firstname", userModel.firstname);
                  cmd.Parameters.AddWithValue("@lastname", userModel.lastname);
                  cmd.Parameters.AddWithValue("@phone", userModel.phone);
                  cmd.Parameters.AddWithValue("@email", userModel.email);
                  cmd.Parameters.AddWithValue("@address", userModel.address);
                cmd.Parameters.AddWithValue("@status", userModel.status);
                cmd.ExecuteNonQuery();
                  con.Close();

                  //return result;

              }
          }

        public void EditLogin(LoginModel loginModel)
        {


            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "UPDATE login SET [username]=@username ,[password]=@password,[usertype]=@usertype where [id]=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", loginModel.username);
                cmd.Parameters.AddWithValue("@password", loginModel.password);
                cmd.Parameters.AddWithValue("@usertype", loginModel.usertype);
                cmd.ExecuteNonQuery();
                con.Close();

                //return result;

            }
        }



        /*public void Delete(ItemModdel itemModdel)
        {


            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "DELETE  FROM item where [id]=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", itemModdel.id);
                //cmd.Parameters.AddWithValue("@name", itemModdel.name);
                //cmd.Parameters.AddWithValue("@amount", itemModdel.amount);
                cmd.ExecuteNonQuery();
                con.Close();

                //return RedirectToPageResult("index");

            }
        }*/


    }
}
