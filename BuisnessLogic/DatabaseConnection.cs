namespace BuisnessLogic.Repository
{
    public interface IDatabaseConnection
    {
        public DatabaseContext DatabaseContext { get; }
        public DatabaseContext TestDatabaseContext { get; }
    }
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly DatabaseContext _context;
        private readonly DatabaseContext _testContext;

        public DatabaseConnection()
        {
            _context = new DatabaseContext();
            _testContext = new TestDatabaseContext();
        }

        public DatabaseContext DatabaseContext { get { return _context; } }
        public DatabaseContext TestDatabaseContext { get { return _testContext; } }
    }
}