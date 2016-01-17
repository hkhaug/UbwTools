using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UbwTools.Common.Storage;

namespace UbwTools.Sql.Database
{
    public class ConnectionHistory
    {
        private static ConnectionHistory _instance;
        public static ConnectionHistory Instance
        {
            get { return _instance ?? (_instance = new ConnectionHistory()); }
        }

        private ConnectionHistory()
        {
        }

        private List<IDatabaseConnection> _connections = new List<IDatabaseConnection>();

        public bool IsEmpty
        {
            get
            {
                if (0 == _connections.Count)
                {
                    LoadAll();
                }
                return (0 == _connections.Count);
            }
        }

        public IEnumerable GetItems()
        {
            return _connections;
        }

        public bool Exists(IDatabaseConnection connection)
        {
            LoadAll();
            return _connections.Any(connectionData => connection.Name == connectionData.Name);
        }

        public bool Identical(IDatabaseConnection connection)
        {
            LoadAll();
            foreach (IDatabaseConnection existingConnection in _connections)
            {
                if (connection.Equals(existingConnection)) return true;
                if (connection.Name == existingConnection.Name) return false;
            }
            return false;
        }

        public void LoadAll()
        {
            _connections = Repository.Sql.Connections.LoadAll();
        }

        public void Save(IDatabaseConnection connection)
        {
            LoadAll();
            DeleteFromList(connection.Name);
            _connections.Insert(0, connection);
            SaveAll();
        }

        public void MoveToTop(IDatabaseConnection connection)
        {
            Save(connection);
        }

        private void DeleteFromList(string name)
        {
            for (int index = 0; index < _connections.Count; ++index)
            {
                if (_connections[index].Name == name)
                {
                    _connections.RemoveAt(index);
                    return;
                }
            }
        }

        private void SaveAll()
        {
            Repository.Sql.Connections.ClearAndSave(_connections);
        }

        public IDatabaseConnection Get(string requestedConnectionName)
        {
            LoadAll();
            foreach (IDatabaseConnection connection in _connections)
            {
                if (connection.Name.Equals(requestedConnectionName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return connection;
                }
            }
            return null;
        }

        public void Delete(string name)
        {
            LoadAll();
            int index = _connections.FindIndex(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (index >= 0)
            {
                _connections.RemoveAt(index);
                SaveAll();
            }
        }
    }
}
