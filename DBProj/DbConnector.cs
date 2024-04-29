using System;

namespace DbConencterContainer
{
	public class DbConnector
	{
		public DbConnector()
		{

		}

		static public string getDbAddress()
		{
			return "Data Source=DESKTOP-848194J\\SQLEXPRESS;Initial Catalog=WebApp;Integrated Security=True";

		}

	}
}