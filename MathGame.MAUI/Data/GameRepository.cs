using SQLite;


namespace MathGame.MAUI.Data
{
    public class GameRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;
            // Ensure a single connection and create the table at construction time so
            // the schema exists before any Add/Delete/Get operations are invoked.
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Models.Game>();
        }
        public void Init()
        {
            // kept for compatibility, no-op because constructor already initializes the DB
            if (conn == null)
            {
                conn  = new SQLiteConnection(_dbPath);
                conn.CreateTable<Models.Game>();
            }
        }

        public List<Models.Game> GetAllGames()
        {
            return conn.Table<Models.Game>().ToList();
        }

        public void Add(Models.Game game)
        {
            // reuse the established connection instead of recreating one per call
            conn.Insert(game);
        }

        public void Delete(int id)
        {
            // reuse the established connection instead of recreating one per call
            conn.Delete(new Models.Game { Id = id});
        }
    }
}
