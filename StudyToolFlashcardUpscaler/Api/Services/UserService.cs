using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyToolFlashcardUpscaler.Models.Dtos;

namespace StudyToolFlashcardUpscaler.Api.Services
{
    public class UserService
    {
        private readonly DatabaseService _databaseService;
        readonly Random rnd = new Random();

        public UserService(DatabaseService database)
        {
            _databaseService = database;
            _databaseService.LoadData();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _databaseService.GetUsers();
        }

        public UserDto CreateUser(UserDto newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "User data cannot be null.");
            }

            newUser.id = rnd.Next(1,int.MaxValue);;

             if (_databaseService.Data!.notes == null)
                _databaseService.Data.notes = [];

            _databaseService.Data.users!.Add(newUser);
            _databaseService.SaveData();

            return newUser;
        }
    }
}