using UbwTools.Sql.Database;
using UbwTools.Sql.Gui;

namespace UbwTools.Sql
{
    public static class SqlCommon
    {
        public static SqlGuiForm SqlForm { get; set; }

        private static ConnectionHistory _connectionHistory;
        public static ConnectionHistory History
        {
            get { return _connectionHistory ?? (_connectionHistory = ConnectionHistory.Instance); }
        }

        private static ConnectionManager _connectionManager;
        public static ConnectionManager Connections
        {
            get { return _connectionManager ?? (_connectionManager = ConnectionManager.Instance); }
        }

        private static DatabaseContentManager _databaseContentManager;
        public static DatabaseContentManager DatabaseContent
        {
            get { return _databaseContentManager ?? (_databaseContentManager = DatabaseContentManager.Instance); }
        }

        private static ExecutionManager _executionManager;

        public static ExecutionManager Executor
        {
            get { return _executionManager ?? (_executionManager = ExecutionManager.Instance); }
        }

        private static FavoritesManager _favoritesManager;
        public static FavoritesManager Favorites
        {
            get { return _favoritesManager ?? (_favoritesManager = FavoritesManager.Instance); }
        }

        private static FileManager _fileManager;
        public static FileManager Files
        {
            get { return _fileManager ?? (_fileManager = FileManager.Instance); }
        }

        private static SqlUserSettings _settings;
        public static SqlUserSettings Settings
        {
            get { return _settings ?? (_settings = SqlUserSettings.Instance); }
        }

        private static StatementManager _statementManager;
        public static StatementManager Statements
        {
            get { return _statementManager ?? (_statementManager = StatementManager.Instance); }
        }

        private static StatusBarController _statusBarController;
        public static StatusBarController Status
        {
            get { return _statusBarController ?? (_statusBarController = StatusBarController.Instance); }
        }
    }
}
