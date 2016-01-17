using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace UbwTools.Common
{
    public static class Global
    {
        public const string FullTitle = "Unit4 Business World Tools";
        public const string ShortTitle = "UBW Tools";

        private static DateTime? _buildDateTime;
        public static DateTime BuildDateTime
        {
            get
            {
                if (null == _buildDateTime)
                {
                    // Read build date+time out of the PE header
                    const int cPeHeaderOffset = 60;
                    const int cLinkerTimestampOffset = 8;
                    string filePath = Assembly.GetCallingAssembly().Location;
                    byte[] b = new byte[2048];
                    Stream s = null;

                    try
                    {
                        s = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        s.Read(b, 0, 2048);
                    }
                    finally
                    {
                        if (s != null)
                        {
                            s.Close();
                        }
                    }

                    int i = BitConverter.ToInt32(b, cPeHeaderOffset);
                    int secondsSince1970 = BitConverter.ToInt32(b, i + cLinkerTimestampOffset);
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
                    dt = dt.AddSeconds(secondsSince1970);
                    dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
                    _buildDateTime = dt;
                }
                return _buildDateTime.Value;
            }
        }

        private static string _publishedVersion;
        public static string PublishedVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_publishedVersion))
                {
                    _publishedVersion = ReadPublishedVersion();
                }
                return _publishedVersion;
            }
        }

        private static string ReadPublishedVersion()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            return versionInfo.FileVersion;
        }

        private static bool _domainKnown;
        private static bool _isUnit4Domain;
        public static bool IsUnit4Domain
        {
            get
            {
                if (!_domainKnown)
                {
                    _isUnit4Domain = "CORPU4AGR".Equals(Environment.UserDomainName,
                        StringComparison.InvariantCultureIgnoreCase);
                    _domainKnown = true;
                }
                return _isUnit4Domain;
            }
        }
    }
}
