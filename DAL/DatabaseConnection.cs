using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void uploadMeasurement(string CPR, int UserID, string kommentar, byte[] readings, int calibrationID)
        {
            DateTime currentTime = DateTime.Now;
            _command = new SqlCommand("INSERT INTO MaalingDB(Patient,AnsvarligID, Maaling, Dato,Kommentar, CalibrationID) VALUES (@Patient, @Ansvarlig, @Maaling, @Dato, @Kommentar, @CalibrationID)", conn);
            _command.Parameters.AddWithValue("@Patient", CPR);
            _command.Parameters.AddWithValue("@Ansvarlig", UserID);
            _command.Parameters.AddWithValue("@Maaling", readings);
            _command.Parameters.AddWithValue("@Dato", currentTime);
            _command.Parameters.AddWithValue("@Kommentar", kommentar);
            _command.Parameters.AddWithValue("@CalibrationID", calibrationID);

            try
            {
                conn.Open();
                _sqlDataReader = _command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                MessageBox.Show("The entered data has been saved");
            }
        }

        public CalibrationValuesDTO getCalibrationValues()
        {
            CalibrationValuesDTO calibrationValues = new CalibrationValuesDTO();
            _command = new SqlCommand("SELECT TOP 1 * FROM dbo.calibrationDB ORDER BY CurrentDate DESC",conn);
            try
            {
                conn.Open();
                _sqlDataReader =_command.ExecuteReader(); // nu indeholder _sqlDataReader-objektet resultatet af forespørgslen
                while (_sqlDataReader.Read())
                {
                    calibrationValues.Intercept = Convert.ToDouble(_sqlDataReader.GetString(4));
                    calibrationValues.Slope = Convert.ToDouble(_sqlDataReader.GetString(5));
                    calibrationValues.ID = _sqlDataReader.GetInt32(0);
                    calibrationValues.Intercept = Convert.ToDouble(_sqlDataReader.GetString(5));
                    calibrationValues.Slope = Convert.ToDouble(_sqlDataReader.GetString(4));
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               throw;
            }
            return calibrationValues;
        }


        public double[] GetSlopeInterceptDoubles()
        {
            _command = new SqlCommand("SELECT TOP 1 * FROM dbo.calibrationDB ORDER BY CurrentDate DESC");
            conn.Open();
            double[] SlopeInterceptList = new double[2];
                // Udføre det ønskede SQL statement på DB
            _sqlDataReader = _command.ExecuteReader(); // nu indeholder _sqlDataReader-objektet resultatet af forespørgslen

                while (_sqlDataReader.Read())
                {
                    SlopeInterceptList = new[] {_sqlDataReader.GetDouble(3), _sqlDataReader.GetDouble(4)};
                }
                conn.Close();
            return SlopeInterceptList;
        }

        public void uploadCalibration(CalibrationValuesDTO calibrationValuesDto)
        {
            DateTime currentTime = DateTime.Now;
            //_command = new SqlCommand("INSERT INTO dbo.calibrationDB(Mmhg10,Mmhg50,Mmhg100,CurrentDate) VALUES ('" + calibrationValuesDto.getSingleValue(0) + "', '" + calibrationValuesDto.getSingleValue(1) + "', '" + calibrationValuesDto.getSingleValue(2) + "', '" + calibrationValuesDto.Slope + "', '"+ calibrationValuesDto.Intercept+ ", '" + currentTime + "')", conn);
            
            _command = new SqlCommand("INSERT INTO dbo.calibrationDB(Mmhg10,Mmhg50,Mmhg100,Slope,Intercept, CurrentDate) VALUES (@Mmhg10, @Mmhg50, @Mmhg100, @Slope, @Intercept, @Date)",conn);
            _command.Parameters.AddWithValue("@Mmhg10", calibrationValuesDto.getValues()[0]);
            _command.Parameters.AddWithValue("@Mmhg50", calibrationValuesDto.getValues()[1]);
            _command.Parameters.AddWithValue("@Mmhg100", calibrationValuesDto.getValues()[2]);
            _command.Parameters.AddWithValue("@Slope", calibrationValuesDto.Slope);
            _command.Parameters.AddWithValue("@Intercept", calibrationValuesDto.Intercept);
            _command.Parameters.AddWithValue("@Date", currentTime);
            
            try
            {
               
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
