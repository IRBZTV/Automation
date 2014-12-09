using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Reviewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

          //  String thisprocessname = Process.GetCurrentProcess().ProcessName;

            //Process[] Pr = Process.GetProcessesByName(thisprocessname);
            //if(Pr.Length>0)
            //{
            //    Pr[0].Kill();
            //}

            if(args.Length>0)
            {
                //MessageBox.Show(args[0].ToString());
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(args[0].ToString()));
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(null));
                //MessageBox.Show("Please Change Default App and Open File");
              //  MessageBox.Show("Please Change Default App and Open File", "Reviewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1(""));
            }
            
        }
    }
}
