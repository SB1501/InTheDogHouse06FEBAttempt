﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheDogHouse06FEBAttempt; //check if this needs to be here


namespace InTheDogHouse06FEBAttempt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmEditDelBooking()); //CHANGE FOR NOW TO GO BETWEEN frmCustomer and frmDog and frmBooking
        }
    }
}