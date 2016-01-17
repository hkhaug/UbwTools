using System;
using System.Collections.Generic;
using System.Linq;
using UbwTools.Common.Storage;

namespace UbwTools.Launch
{
    public class QuickDatabases
    {
        private List<string> _names = new List<string>();

        public void Add(string name)
        {
            LoadAll();
            if (!Exists(name))
            {
                _names.Add(name);
                SaveAll();
            }
        }

        public void Delete(string name)
        {
            LoadAll();
            if (Exists(name))
            {
                bool deleted = _names.Remove(name);
                while (deleted)
                {
                    deleted = _names.Remove(name);
                }
                SaveAll();
            }
        }

        private bool Exists(string name)
        {
            foreach (string existingName in _names)
            {
                if (existingName.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void LoadAll()
        {
            _names = Repository.Launch.Databases.GetValueNames().ToList();
        }

        private void SaveAll()
        {
            Repository.Launch.Databases.ClearAndSaveList(_names);
        }

        public IEnumerable<string> Names
        {
            get
            {
                LoadAll();
                return _names;
            }
        }
    }
}
