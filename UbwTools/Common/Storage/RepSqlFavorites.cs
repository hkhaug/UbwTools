namespace UbwTools.Common.Storage
{
    public class RepSqlFavorites : RepBase
    {
        private static RepSqlFavorites _instance;

        public static RepSqlFavorites Instance
        {
            get { return _instance ?? (_instance = new RepSqlFavorites()); }
        }

        private RepSqlFavorites() : base(RepSql.Instance, "Favorites")
        {
        }

        public RepSqlFavoritesTables Tables
        {
            get { return RepSqlFavoritesTables.Instance; }
        }

        public RepSqlFavoritesViews Views
        {
            get { return RepSqlFavoritesViews.Instance; }
        }

        public RepSqlFavoritesStatements Statements
        {
            get { return RepSqlFavoritesStatements.Instance; }
        }
    }
}
