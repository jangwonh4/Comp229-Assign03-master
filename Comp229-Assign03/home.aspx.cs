﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class home : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
           

            SqlCommand comm = new SqlCommand("SELECT * FROM Students", conn);
            
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                reader.Close();
                conn.Close();
            
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            SqlCommand InsertName = new SqlCommand("INSERT INTO Comp229Assign03.[dbo].Students (FirstMidName, LastName, EnrollmentDate) VALUES(@FirstName, @LastName, @EnrollmentDate); ", conn);


            InsertName.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
            InsertName.Parameters["@FirstName"].Value = BoxFName.Text;

            InsertName.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
            InsertName.Parameters["@LastName"].Value = BoxLName.Text;

            InsertName.Parameters.Add("@EnrollmentDate", System.Data.SqlDbType.Date);
            InsertName.Parameters["@EnrollmentDate"].Value = DateTime.Now;
         
            conn.Open();
            InsertName.ExecuteNonQuery();
            conn.Close();
 
                    
 
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = GridView1.SelectedRow;
            string STUDENT = row.Cells[1].Text;
            Response.Redirect("Student.aspx?Name=" + STUDENT );
        }

    }
}