using LearningApp.Application.InfrastructureInterfaces.Persistance;
using LearningApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.Persistance
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthDataService : IAuthDataService
    {
        private readonly DemoAppDbContext _demoAppDbContext;
        public AuthDataService(DemoAppDbContext demoAppDbContext)
        {
            _demoAppDbContext = demoAppDbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> AddUserInDB(User user)
        {
            try
            {
                var createdUser = await _demoAppDbContext.Users.AddAsync(user);
                _demoAppDbContext.SaveChanges();
                return createdUser.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to pull Users from Database Using EF
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUsersFromDBAsync()
        {
            try
            {
                return await _demoAppDbContext.Users.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
