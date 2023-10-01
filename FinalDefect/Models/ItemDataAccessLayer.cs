using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDefect.Models
{
    public class ItemDataAccessLayer
    {
        //Data Source=MATHULA;Initial Catalog=defect;Integrated Security=True
        string con_string = "Data Source=MATHULA;Initial Catalog=asp;Integrated Security=True";

        public IEnumerable<ItemModdel> Refresh()
        {
            List<ItemModdel> objModel = new List<ItemModdel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "select * from item";
                SqlCommand cmd = new SqlCommand(query, con);
                ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ItemModdel tempModel = new ItemModdel();
                    tempModel.id = int.Parse(rdr["id"].ToString());
                    tempModel.name = rdr["name"].ToString();
                    tempModel.amount = Convert.ToDecimal(rdr["amount"].ToString());
                    objModel.Add(tempModel);
                }
                con.Close();
            }
            return objModel;

        }
        public ItemModdel Find(int id)
        {
            ItemModdel objModel = new ItemModdel();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(con_string))
            {
               
                string query = "select * from item where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                //ConnectionState stat = con.State;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   // ItemModdel tempModel = new ItemModdel();
                    objModel.id = int.Parse(rdr["id"].ToString());
                    objModel.name = rdr["name"].ToString();
                    objModel.amount = Convert.ToDecimal(rdr["amount"].ToString());
                    //objModel.Add(tempModel);
                }
                //con.Close();
            }
            return objModel;

        }
        public void Create(ItemModdel itemModdel)
        {


            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "INSERT INTO item ([name],[amount]) VALUES ( @name , @amount )";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", itemModdel.name);
                cmd.Parameters.AddWithValue("@amount", itemModdel.amount);
                cmd.ExecuteNonQuery();
                con.Close();

                //return result;

            }
        }

      

        public void Edit(ItemModdel itemModdel)
        {


            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "UPDATE item SET [name]=@name , [amount]=@amount where [id]=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", itemModdel.id);
                cmd.Parameters.AddWithValue("@name", itemModdel.name);
                cmd.Parameters.AddWithValue("@amount", itemModdel.amount);
                cmd.ExecuteNonQuery();
                con.Close();

                //return result;

            }
        }

        public void Delete(ItemModdel itemModdel)
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
        }





        /* public string insert()
{
   duration = txtduration.Text + " " + cmbduration.Text;
   SqlCommand cmd = new SqlCommand("INSERT INTO program VALUES ('" + txtid.Text + "','" + txtname.Text + "','" + duration + "','" + txtpayment.Text + "')", con);
   con.Open();
   cmd.ExecuteNonQuery();
   MessageBox.Show("Added successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
   txtname.Clear();
   txtduration.Clear();
   txtpayment.Clear();

   con.Close();
}
public string update()
{
   SqlCommand cmd = new SqlCommand("UPDATE program SET name='" + txtnameup.Text + "',duration= '" + upduration + "',payment= '" + txtpaymentup.Text + "' WHERE id LIKE '" + txtsearchbyid.Text + "'", con);
   con.Open();
   cmd.ExecuteNonQuery();
   MessageBox.Show("Updated successfully...", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
   txtname.Clear();
   txtduration.Clear();
   txtpayment.Clear();

   txtsearchbyid.Clear();
   con.Close();
}
public string delete()
{

}*/

    }

}

