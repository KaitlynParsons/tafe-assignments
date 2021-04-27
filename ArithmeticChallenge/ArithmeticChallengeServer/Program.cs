﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Program.cs
//
// summary:	Implements the program class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArithmeticChallenge
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A program. </summary>
    ///
    /// <remarks>   Parsons, 16-Sep-18. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static class Program
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The main entry point for the application. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
