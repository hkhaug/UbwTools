namespace UbwTools.Common.Storage
{
    public class RepSqlFavoritesViews : RepBase
    {
        private static RepSqlFavoritesViews _instance;

        public static RepSqlFavoritesViews Instance
        {
            get { return _instance ?? (_instance = new RepSqlFavoritesViews()); }
        }

        private RepSqlFavoritesViews() : base(RepSqlFavorites.Instance, "Views")
        {
        }
    }
}
