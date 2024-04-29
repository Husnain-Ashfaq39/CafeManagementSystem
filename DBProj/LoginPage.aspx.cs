﻿using System;
using System.Data.SqlClient;
using System.Web.UI;
using DbConencterContainer;

namespace DBProj
{
    public partial class LoginPage : Page
    {
        private string connectionString = DbConnector.getDbAddress();

        protected void Login_Click(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT UserId, RoleId FROM Users WHERE Username = @username AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(reader.GetOrdinal("UserId"));
                                int roleId = reader.GetInt32(reader.GetOrdinal("RoleId"));

                                Session["UserId"] = userId;
                                Session["Username"] = username;

                                switch (roleId)
                                {
                                    case 1: // Admin
                                        Response.Redirect("InventoryHome.aspx");
                                        break;
                                    case 2: // cashier
                                        Response.Redirect("PaymentDetails.aspx");
                                        break;
                                    case 3: // Customer
                                        Response.Redirect("PlaceOrders.aspx");
                                        break;
                                    case 4: // manager
                                        Response.Redirect("ManagerHome.aspx");
                                        break;

                                        //InventoryHome
                                }
                            }
                            else
                            {
                                // Invalid login
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Incorrect username or password.');", true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

    }
}