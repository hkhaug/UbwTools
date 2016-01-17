using System.Collections.Generic;
using Microsoft.Win32;

namespace UbwTools.Common.Storage
{
    public class RepBase
    {
        protected readonly RegistryKey Key;

        protected RepBase(RegistryKey parent, string path)
        {
            Key = parent.CreateSubKey(path);
        }

        protected RepBase(RepBase parent, string path) : this(parent.Key, path)
        {
        }

        public string GetString(string name)
        {
            return (string) Key.GetValue(name);
        }

        public void SetString(string name, string value)
        {
            Key.SetValue(name, value);
        }

        public void ClearAndSaveList(IEnumerable<string> items)
        {
            ClearAllValues();
            SaveList(items);
        }

        public void ClearAndSaveList(IEnumerable<IRepBinary> items)
        {
            ClearAllValues();
            SaveList(items);
        }

        private void ClearAllValues()
        {
            IEnumerable<string> names = Key.GetValueNames();
            foreach (string name in names)
            {
                Key.DeleteValue(name, false);
            }
        }

        protected void ClearAllSubkeys()
        {
            IEnumerable<string> names = Key.GetSubKeyNames();
            foreach (string name in names)
            {
                Key.DeleteSubKey(name, false);
            }
        }

        private void SaveList(IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                Key.SetValue(item, string.Empty);
            }
        }

        private void SaveList(IEnumerable<IRepBinary> items)
        {
            foreach (IRepBinary item in items)
            {
                byte[] data = item.Value ?? new byte[0];
                Key.SetValue(item.Name, data, RegistryValueKind.Binary);
            }
        }

        public IEnumerable<string> GetValueNames()
        {
            return Key.GetValueNames();
        }

        public IEnumerable<IRepBinary> GetBinaryItems()
        {
            List<IRepBinary> result = new List<IRepBinary>();
            foreach (string name in Key.GetValueNames())
            {
                byte[] value = (byte[]) Key.GetValue(name);
                result.Add(new RepBinary(name, value));
            }
            return result;
        }
    }
}
