using System.Diagnostics;
using System.Windows.Forms;

namespace UbwTools.Common
{
    public class LaunchManager
    {
        public const string IdBflagCalculatorSimple = "BFS";
        public const string IdBflagCalculatorAdvanced = "BFA";
        public const string IdNorwegianIdentityNumbers = "NIN";
        public const string IdDatabase = "DB";

        private static LaunchManager _instance;
        public static LaunchManager Instance
        {
            get { return _instance ?? (_instance = new LaunchManager()); }
        }

        private LaunchManager()
        {
        }

        public void LaunchNewInstance(string parameters)
        {
            string exePath = Application.ExecutablePath;
            Process.Start(exePath, parameters);
        }

        public void LaunchSimpleBflagCalculator()
        {
            LaunchNewInstance(IdBflagCalculatorSimple);
        }

        public void LaunchAdvancedBflagCalculator()
        {
            LaunchNewInstance(IdBflagCalculatorAdvanced);
        }

        public void LaunchNorwegianIdentityNumbers()
        {
            LaunchNewInstance(IdNorwegianIdentityNumbers);
        }

        public void LaunchDatabase()
        {
            LaunchNewInstance(IdDatabase);
        }

        public void LaunchDatabase(string connectionName)
        {
            LaunchNewInstance(string.Format("{0} \"{1}\"", IdDatabase, connectionName));
        }
    }
}
