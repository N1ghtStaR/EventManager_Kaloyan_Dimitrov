namespace Event_Manager_DB
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            SetDefaultConnectionFactory(
                new LocalDbConnectionFactory("MSSQLLocalDB")
            );
        }
    }
}
