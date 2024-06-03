using LearningApp.Application.InfrastructureInterfaces.Persistance;
using LearningApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthDataService _authDataService;
        public AuthService(IAuthDataService authDataService)
        {
            _authDataService = authDataService;
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                return await _authDataService.AddUserInDB(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetUserssAsync()
        {
            try
            {
                return await _authDataService.GetUsersFromDBAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
