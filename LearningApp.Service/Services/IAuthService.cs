using LearningApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Services
{
    public interface IAuthService
    {
        Task<User> AddUser(User user);
        public Task<List<User>> GetUserssAsync();
    }
}
