using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbConencterContainer;

namespace DBProj
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Ensure data is only loaded on the initial page load
            {
                string connectionString = DbConnector.getDbAddress();
                string query = "SELECT ID, FileName, FileContent FROM Pictures";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    // Create a DataTable to hold the data
                    DataTable dt = new DataTable();

                    // Create a SqlDataAdapter and set its SelectCommand
                    SqlDataAdapter sd = new SqlDataAdapter(command);

                    // Fill the DataTable with data from the database
                    sd.Fill(dt);
                    dt.Columns.Add("Pic", Type.GetType("System.Byte[]"));
                    foreach (DataRow drow in dt.Rows)
                    {
                        //drow["Pic"] = File.ReadAllBytes(drow["FileContent"].ToString());
                        drow["Pic"] = (byte[])drow["FileContent"];

                    }

                    // Bind the DataTable to the GridView
                    GridView1.DataSource = dt;
                    GridView1.DataBind(); // Bind the data to the GridView

                    // No need to call ExecuteNonQuery as we are only retrieving data
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    // Get file name and file extension
                    string fileName = Path.GetFileName(fileUpload.FileName);
                    string fileExtension = Path.GetExtension(fileName);

                    // Check if the file extension is allowed (e.g., JPG, PNG)
                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                    {
                        // Get file content
                        byte[] fileBytes = fileUpload.FileBytes;

                        // Save file to database
                        SaveFileToDatabase(fileName, fileBytes);

                        // Display success message
                        Response.Write("<script>alert('File uploaded successfully!');</script>");
                    }
                    else
                    {
                        // Display error message for invalid file format
                        Response.Write("<script>alert('Invalid file format! Only JPG and PNG files are allowed.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Display error message for general exceptions
                    Response.Write("<script>alert('An error occurred while uploading the file. Please try again later.');</script>");
                }
            }
            else
            {
                // Display error message for no file selected
                Response.Write("<script>alert('Please select a file to upload.');</script>");
            }
        }
        private void SaveFileToDatabase(string fileName, byte[] fileBytes)
        {
            string connectionString = DbConnector.getDbAddress();
            string query = "INSERT INTO Pictures (FileName, FileContent) VALUES (@FileName, @FileContent)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FileName", fileName);
                command.Parameters.AddWithValue("@FileContent", fileBytes);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}