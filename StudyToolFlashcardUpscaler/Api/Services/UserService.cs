using StudyToolFlashcardUpscaler.Models.Dtos;

namespace StudyToolFlashcardUpscaler.Api.Services
{
    public class UserService
    {
        private readonly DatabaseService _database;
        readonly Random rnd = new Random();

        public UserService(DatabaseService database)
        {
            _database = database;
            _database.LoadData();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _database.GetUsers();
        }

        public UserDto CreateUser(UserDto newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "User data cannot be null.");
            }

             if (_database.Data!.users == null)
                _database.Data.users = [];

            var highestId = _database.Data.users.Max(x => x.Id);
                newUser.Id = highestId + 1;

            _database.Data.users!.Add(newUser);
            _database.SaveData();

            return newUser;
        }
        public UserDto AuthenticateUser(string username, string password)
        {
            var allUsersResults = GetAllUsers();// or _users, whichever is consistent
            return allUsersResults.FirstOrDefault(u => u.username == username && u.password == password);
        }
    }
}