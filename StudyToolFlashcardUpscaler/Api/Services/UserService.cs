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

        public UserService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            _databaseService.LoadData();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _databaseService.GetUsers();
        }
    }
}