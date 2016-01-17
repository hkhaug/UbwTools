using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace UbwTools.Common.Gui
{
    public static class IconSucker
    {
        [Flags]
        private enum LoadLibraryFlags : uint
        {
            // ReSharper disable UnusedMember.Local
            // ReSharper disable InconsistentNaming
            DONT_RESOLVE_DLL_REFERENCES = 0x00000001,
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,
            LOAD_LIBRARY_AS_DATAFILE = 0x00000002,
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,
            LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
            // ReSharper restore UnusedMember.Local
            // ReSharper restore InconsistentNaming
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadImage(IntPtr hinst, uint lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, LoadLibraryFlags dwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", EntryPoint = "EnumResourceNamesW", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool EnumResourceNames(IntPtr hModule, int dwId, EnumResNameProcDelegate lpEnumFunc, IntPtr lParam);

        delegate bool EnumResNameProcDelegate(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam);

        private static bool IS_INTRESOURCE(IntPtr value)
        {
            return ((uint)value) <= ushort.MaxValue;
        }

        private static string GET_RESOURCE_NAME(IntPtr value)
        {
            return IS_INTRESOURCE(value) ? value.ToString() : Marshal.PtrToStringUni(value);
        }

        public static Icon GetFirstIconFromExe(string path, int size)
        {
            return GetNumberedIconFromExe(path, size, 0) ?? GetFirstNamedIconFromExe(path, size);
        }

        private static readonly List<string> AllResourceNames = new List<string>();

        private static Icon GetFirstNamedIconFromExe(string path, int size)
        {
            IntPtr h = LoadLibraryEx(path, IntPtr.Zero, LoadLibraryFlags.LOAD_LIBRARY_AS_DATAFILE | LoadLibraryFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
            if (IntPtr.Zero == h)
            {
                return null;
            }

            try
            {
                AllResourceNames.Clear();
                EnumResourceNames(h, 14, EnumAllRes, IntPtr.Zero);
                foreach (string resourceName in AllResourceNames)
                {
                    IntPtr ptr = LoadImage(h, resourceName, 1, size, size, 0);
                    if (IntPtr.Zero != ptr)
                    {
                        try
                        {
                            Icon icon = (Icon)Icon.FromHandle(ptr).Clone();
                            return icon;
                        }
                        finally
                        {
                            DestroyIcon(ptr);
                        }
                    }
                }
            }
            finally
            {
                FreeLibrary(h);
            }
            return null;
        }

        private static bool EnumAllRes(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam)
        {
            AllResourceNames.Add(GET_RESOURCE_NAME(lpszName));
            return true;
        }

        public static Icon GetNumberedIconFromExe(string path, int size, int iconNumber)
        {
            IntPtr h = LoadLibraryEx(path, IntPtr.Zero, LoadLibraryFlags.LOAD_LIBRARY_AS_DATAFILE | LoadLibraryFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
            if (IntPtr.Zero == h)
            {
                return null;
            }

            try
            {
                if (iconNumber < 0)
                {
                    uint id = (uint) -iconNumber;
                    IntPtr ptr = LoadImage(h, id, 1, size, size, 0);
                    if (IntPtr.Zero != ptr)
                    {
                        try
                        {
                            Icon icon = (Icon)Icon.FromHandle(ptr).Clone();
                            return icon;
                        }
                        finally
                        {
                            DestroyIcon(ptr);
                        }
                    }
                }
                else
                {
                    int found = 0;
                    int toBeFound = iconNumber < 0 ? -iconNumber : iconNumber;
                    for (uint id = 0; id < Int16.MaxValue; ++id)
                    {
                        IntPtr ptr = LoadImage(h, id, 1, size, size, 0);
                        if (IntPtr.Zero != ptr)
                        {
                            try
                            {
                                if (found == toBeFound)
                                {
                                    Icon icon = (Icon) Icon.FromHandle(ptr).Clone();
                                    return icon;
                                }
                                ++found;
                            }
                            finally
                            {
                                DestroyIcon(ptr);
                            }
                        }
                    }
                }
            }
            finally
            {
                FreeLibrary(h);
            }
            return null;
        }
    }
}
