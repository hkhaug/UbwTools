using System.Collections.Generic;

namespace UbwTools.Common.Storage
{
    public class RepSqlFavoritesTables : RepBase
    {
        private static RepSqlFavoritesTables _instance;

        public static RepSqlFavoritesTables Instance
        {
            get { return _instance ?? (_instance = new RepSqlFavoritesTables()); }
        }

        private RepSqlFavoritesTables() : base(RepSqlFavorites.Instance, "Tables")
        {
        }
    }
}
