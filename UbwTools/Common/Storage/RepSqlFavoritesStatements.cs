namespace UbwTools.Common.Storage
{
    public class RepSqlFavoritesStatements : RepBase
    {
        private static RepSqlFavoritesStatements _instance;

        public static RepSqlFavoritesStatements Instance
        {
            get { return _instance ?? (_instance = new RepSqlFavoritesStatements()); }
        }

        private RepSqlFavoritesStatements() : base(RepSqlFavorites.Instance, "Statements")
        {
        }
    }
}
