using System;
using System.Windows.Forms;
using UbwTools.BFlagCalc;
using UbwTools.Common;
using UbwTools.Launch;
using UbwTools.Nin;
using UbwTools.Sql.Gui;

namespace UbwTools
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string requestedSubapp = null;
            string[] argv = Environment.GetCommandLineArgs();
            if (argv.Length > 1)
            {
                requestedSubapp = argv[1];
            }
            bool again;
            string nextSubParam = null;
            do
            {
                again = false;
                switch (requestedSubapp)
                {
                    case LaunchManager.IdBflagCalculatorSimple:
                        Application.Run(new BflagSimpleGuiForm());
                        break;
                    case LaunchManager.IdBflagCalculatorAdvanced:
                        Application.Run(new BflagAdvancedGuiForm());
                        break;
                    case LaunchManager.IdNorwegianIdentityNumbers:
                        Application.Run(new NinGuiForm());
                        break;
                    case LaunchManager.IdDatabase:
                        Application.Run(new SqlGuiForm(nextSubParam));
                        break;
                    default:
                        LaunchGuiForm frm = new LaunchGuiForm();
                        Application.Run(frm);
                        if (!string.IsNullOrEmpty(frm.NextSubapp))
                        {
                            int p = frm.NextSubapp.IndexOf(' ');
                            if (0 > p)
                            {
                                requestedSubapp = frm.NextSubapp;
                                nextSubParam = null;
                            }
                            else
                            {
                                requestedSubapp = frm.NextSubapp.Substring(0, p);
                                nextSubParam = frm.NextSubapp.Substring(p + 1);
                            }
                            again = true;
                        }
                        break;
                }
            } while (again);
        }
    }
}
