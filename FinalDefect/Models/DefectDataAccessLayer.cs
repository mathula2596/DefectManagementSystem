using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDefect.Models
{
    public class DefectDataAccessLayer 
    {
        string con_string = "Data Source=MATHULA;Initial Catalog=defect;Integrated Security=True";
       

        public IEnumerable<DefectModel> Refresh()
        {
            List<DefectModel> objModel = new List<DefectModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "select * from defect";
                SqlCommand cmd = new SqlCommand(query, con);
                ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DefectModel tempModel = new DefectModel();
                    tempModel.id = int.Parse(rdr["id"].ToString());
                    tempModel.project_name = rdr["project_name"].ToString();
                    tempModel.description = rdr["description"].ToString();
                    tempModel.status = rdr["status"].ToString();
                    tempModel.assign_to = rdr["assign_to"].ToString();
                   // tempModel.date = DateTime.Parse(rdr["date"].ToString());
                    objModel.Add(tempModel);
                }
                con.Close();
            }
            return objModel;

        }
      /*  public ActionResult Fname()
        {
            List<DefectModel> objModel = new List<DefectModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
               SqlDataAdapter _da = new SqlDataAdapter( "select * from users inner join  login on users.id=login.id where login.usertype='Developer'",con);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);
                ViewBag.
                SqlCommand cmd = new SqlCommand(query, con);
                ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DefectModel tempModel = new DefectModel();
                    tempModel.id = int.Parse(rdr["id"].ToString());
                    tempModel.firstname = rdr["firstname"].ToString();
       
                    // tempModel.date = DateTime.Parse(rdr["date"].ToString());
                    objModel.Add(tempModel);
                }
                con.Close();
            }
            return objModel;

        }*/

       

        public DefectModel Find(int id)
        {
            DefectModel objModel = new DefectModel();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(con_string))
            {

                string query = "select * from defect where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                //ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // ItemModdel tempModel = new ItemModdel();
                    objModel.id = int.Parse(rdr["id"].ToString());
                    objModel.project_name = rdr["project_name"].ToString();
                    objModel.description = rdr["description"].ToString();
                    objModel.status = rdr["status"].ToString();
                    objModel.assign_to = rdr["assign_to"].ToString();
                  
                    //objModel.Add(tempModel);
                }
                //con.Close();
            }
            return objModel;

        }
    
        public void Create(DefectModel defectModel)
        {
            //Findid();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                //Findid();
                con.Open();
                string query = "INSERT INTO defect ([project_name],[description],[status],[assign_to]) output INSERTED.ID VALUES ( @project_name , @description,@status,@assign_to )";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@project_name", defectModel.project_name);
                cmd.Parameters.AddWithValue("@description", defectModel.description);
                cmd.Parameters.AddWithValue("@status", defectModel.status);
                cmd.Parameters.AddWithValue("@assign_to", defectModel.assign_to);


               
                //ConnectionState stat = con.State;
               

                string queryhistory = "INSERT INTO status_history ([status],[change_date],[user_id],[defect_id]) VALUES (@status,@change_date,@user_id,@defect_id)";
                SqlCommand cmdhistory = new SqlCommand(queryhistory, con);
                //cmd.ExecuteNonQuery();
                string now = DateTime.Now.ToString("yyyy/MM/dd");
                int did =(int) cmd.ExecuteScalar();
                cmdhistory.Parameters.AddWithValue("@user_id", defectModel.user_id);
                cmdhistory.Parameters.AddWithValue("@defect_id", did);
                cmdhistory.Parameters.AddWithValue("@status", defectModel.status);
                cmdhistory.Parameters.AddWithValue("@change_date", now);

                
                cmdhistory.ExecuteNonQuery();
                con.Close();



            }
        }

       


        public void Edit(DefectModel defectModel)
        {


            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "UPDATE defect SET [project_name]=@project_name , [description]=@description, [status]=@status, [assign_to]=@assign_to where [id]=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", defectModel.id);
                cmd.Parameters.AddWithValue("@project_name", defectModel.project_name);
                cmd.Parameters.AddWithValue("@description", defectModel.description);
                cmd.Parameters.AddWithValue("@status", defectModel.status);
                cmd.Parameters.AddWithValue("@assign_to", defectModel.assign_to);

                string queryhistory = "INSERT INTO status_history ([status],[change_date],[user_id],[defect_id]) VALUES ( @status,@change_date,@user_id,@defect_id)";
                SqlCommand cmdhistory = new SqlCommand(queryhistory, con);
               // cmd.ExecuteNonQuery();
                string now = DateTime.Now.ToString("yyyy/MM/dd");
               
                cmdhistory.Parameters.AddWithValue("@user_id", defectModel.user_id);
                cmdhistory.Parameters.AddWithValue("@defect_id", defectModel.id);
                cmdhistory.Parameters.AddWithValue("@status", defectModel.status);
                cmdhistory.Parameters.AddWithValue("@change_date", now);


                cmdhistory.ExecuteNonQuery();

                cmd.ExecuteNonQuery();
                con.Close();

                //return result;

            }
        }





    }
}
