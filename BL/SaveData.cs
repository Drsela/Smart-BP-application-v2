using System;
using DAL;
using DTO;

namespace BL
{
    public class SaveData
    {
        private DatabaseConnection _connection;
        private EmployeeDTO _employee;

        public void uploadMeasurementData(string CPR, int UserID, string kommentar, byte[] readings, int calibrationID)
        {
            CPR = CPR.Replace("-", "");
            _connection = new DatabaseConnection();
            _connection.uploadMeasurement(CPR, UserID, kommentar, readings, calibrationID);
        }

        public EmployeeDTO GetEmployeeFromValidation(string UN, string PW)
        {
            _connection = new DatabaseConnection();
            return _connection.GetDto(UN, PW);
        }

        public bool ValidateLogin(string UN, string PW)
        {
            _connection = new DatabaseConnection();
            var isValid = _connection.ValidateLogin(UN, PW);
            if (isValid)
                return true;
            return false;
        }


        public bool ValidateCPR(string PatientCPR)
        {
            var testcpr = 1; //init testcpr = 1
            var sum = 0;
            PatientCPR = PatientCPR.Replace("-", "");
            int[] cprRules = {4, 3, 2, 7, 6, 5, 4, 3, 2, 1};

            if (PatientCPR.Length == 10)
            {
                for (var i = 0; i <= PatientCPR.Length - 1; i++)
                    sum += Convert.ToInt32(Convert.ToString(PatientCPR[i])) * Convert.ToInt32(cprRules[i]);
                testcpr = sum % 11;
            }
            return testcpr == 0;
        }
    }
}