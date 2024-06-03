using LearningApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.InfrastructureInterfaces.Persistance
{
    public interface IAuthDataService
    {
        Task<User> AddUserInDB(User user);
        /// <summary>
        /// Method to pull Users from Database Using EF
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetUsersFromDBAsync();
    }
}
