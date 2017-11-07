using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using DTO;

namespace DAL
{
    public class DatabaseConnection
    {
        private readonly SqlConnection conn;
        private SqlDataReader _sqlDataReader;
        private SqlCommand _command;
        private const string DatabaseString = "F17ST2ITS2201605182"; //Database Login - Remember VPN
        public EmployeeDTO _Employee;
        public DatabaseConnection()
        {
            conn = new SqlConnection("Data Source =i4dab.ase.au.dk; Initial Catalog = " + DatabaseString + "; Persist Security Info = True; User ID =" + DatabaseString + "; password = " + DatabaseString + "");
        }

        public bool ValidateLogin(string UserID, string password)
        {
            // Oprette SQL kommando
            //_command = new SqlCommand("select * from dbo.LoginDB where UserID ='" + UserID + "' and PasswordHash = '" + password + "' COLLATE Latin1_General_CS_AS", conn);
            _command = new SqlCommand("SELECT * FROM LoginDBWithHash WHERE UserID='" + UserID + "' AND PasswordHash=HASHBYTES('SHA2_512','" + password + "')", conn);

            // Åbne DB-forbindelsen
            try
            {
                conn.Open();
                _sqlDataReader = _command.ExecuteReader(); // nu indeholder _sqlDataReader-objektet resultatet af forespørgslen
                if (_sqlDataReader.HasRows == true)
                {

                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("You are not connected to the VPN. Please connect to VPN and try again.");
            }
        }

        public EmployeeDTO GetDto(string UserID, string password)
        {
            _command = new SqlCommand("SELECT * FROM LoginDBWithHash WHERE UserID='" + UserID + "' AND PasswordHash=HASHBYTES('SHA2_512','" + password + "')", conn);

            // Åbne DB-forbindelsen
            conn.Open();

            // Udføre det ønskede SQL statement på DB
            _sqlDataReader = _command.ExecuteReader(); // nu indeholder _sqlDataReader-objektet resultatet af forespørgslen
            if (_sqlDataReader.HasRows == true)
            {
                while (_sqlDataReader.Read())
                {
                    _Employee = new EmployeeDTO(_sqlDataReader.GetInt32(0), _sqlDataReader.GetString(2), _sqlDataReader.GetString(3));
                }
                conn.Close();
            }
            return _Employee;
        }

        public void uploadMeasurement(string CPR, int UserID, string kommentar)
        {
            DateTime currentTime = DateTime.Now;
            _command = new SqlCommand("INSERT INTO MaalingDB(Patient,AnsvarligID,Dato,Kommentar) VALUES ('"+ CPR+"', '"+UserID+"', '"+ currentTime+"', '"+ kommentar+"')",conn);
            conn.Open();
            _sqlDataReader = _command.ExecuteReader();
        }

        public void uploadCalibration(CalibrationValuesDTO calibrationValuesDto)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                _command = new SqlCommand("INSERT INTO dbo.calibrationDB(Mmhg10,Mmhg50,Mmhg100,CurrentDate) VALUES ('" + calibrationValuesDto.getSingleValue(0) + "', '" + calibrationValuesDto.getSingleValue(1) + "', '" + calibrationValuesDto.getSingleValue(2) + "', '" + currentTime + "')", conn);
                conn.Open();
                _sqlDataReader = _command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
