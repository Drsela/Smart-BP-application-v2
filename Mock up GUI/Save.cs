﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using BL;
using DTO;

namespace PL
{
    public partial class Save : Form
    {
        private iBusinessLogic _businessLogic;
        private SaveData _saveData;
        public EmployeeDTO _Employee;
        public Save(iBusinessLogic businessLogic, EmployeeDTO employee)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
            _saveData = new SaveData();
            _Employee = employee;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_saveData.ValidateCPR(CPRtextBox1.Text) == true)
            {
                _saveData.uploadEmployee(CPRtextBox1.Text,_Employee.ID,commentTextBox.Text);
                MessageBox.Show("Success");
                this.Close();
                
            }
                
            else
            {
                MessageBox.Show("Wrong CPR-Number");
            }
        }
    }
}