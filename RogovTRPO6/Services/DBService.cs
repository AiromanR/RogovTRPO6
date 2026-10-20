using RogovTRPO6.Models;

namespace RogovTRPO6.Services

{
    public class DBService
    {
        private WebApiDatabaseContext context;
        public WebApiDatabaseContext Context => context;
        private static DBService? instance;
        public static DBService Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBService();
                return instance;
            }
        }
        private DBService()
        {
            context = new WebApiDatabaseContext();
        }
    }
}