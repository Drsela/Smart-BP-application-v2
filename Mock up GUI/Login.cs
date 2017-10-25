﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Interfaces;

namespace PL
{
    public partial class Login : Form
    {
        private iBusinessLogic _businessLogic;
        private readonly SaveData _saveData;
        public Login(iBusinessLogic businessLogic)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
            _saveData = new SaveData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(_saveData.ValidateLogin(EmployeeID.Text,Password.Text) == true)
            { 
                Save formSave = new Save(_businessLogic);
                formSave.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login \n Please try again");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
