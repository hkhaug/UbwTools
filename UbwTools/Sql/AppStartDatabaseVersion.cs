using System;
using UbwTools.Sql.Database;

namespace UbwTools.Sql
{
    public class AppStartDatabaseVersion
    {
        public int VersionId { get; private set; }
        public string Title { get; private set; }
        public string VerTitle { get; private set; }
        private bool _typeDetermined;
        private DatabaseEngineType _type;

        public DatabaseEngineType DbType
        {
            get
            {
                if (!_typeDetermined)
                {
                    _type = Title.StartsWith("Oracle", StringComparison.InvariantCultureIgnoreCase)
                        ? DatabaseEngineType.Oracle
                        : DatabaseEngineType.SqlServer;
                    _typeDetermined = true;
                }
                return _type;
            }
        }

        public AppStartDatabaseVersion(int versionId, string title, string verTitle)
        {
            VersionId = versionId;
            Title = title;
            VerTitle = verTitle;
        }
    }
}
