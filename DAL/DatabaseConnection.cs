using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseConnection
    {
        private readonly SqlConnection conn;
        private SqlDataReader _sqlDataReader;
        private SqlCommand _command;
        private const string DatabaseString = "F17ST2ITS2201605182"; //Database Login - Remember VPN
        public DatabaseConnection()
        {
            conn = new SqlConnection("Data Source =i4dab.ase.au.dk; Initial Catalog = " + DatabaseString + "; Persist Security Info = True; User ID =" + DatabaseString + "; password = " + DatabaseString + "");
        }

        public bool ValidateLogin(string UserID, string password)
        {
            // Oprette SQL kommando
            _command = new SqlCommand("select * from dbo.LoginDB where UserID ='" + UserID + "' and PasswordHash = '" + password + "' COLLATE Latin1_General_CS_AS", conn);

            // Åbne DB-forbindelsen
            conn.Open();

            // Udføre det ønskede SQL statement på DB
            _sqlDataReader = _command.ExecuteReader(); // nu indeholder _sqlDataReader-objektet resultatet af forespørgslen
            if (_sqlDataReader.HasRows == true)
            {
                conn.Close();
                return true;
            }
            else { 
                conn.Close();
                return false;
            }
        }
    }
}
