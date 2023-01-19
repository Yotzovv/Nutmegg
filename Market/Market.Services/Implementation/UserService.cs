using AutoMapper.QueryableExtensions;
using Market.Data;
using Market.Data.Models;
using Market.Services.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<UserProfileServiceModel> GetProfileAsync(string username)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                return null;
            }

            var profile = new UserProfileServiceModel
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                BirthDate = user.Birthdate,
                IsEmailConfirmed = user.EmailConfirmed,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                Area = user.Area,
                ProfilePicture = user.ProfilePicture,
                Prestige = user.Prestige,
                Posts = user.Posts.Select(p => new ProductListingServiceModel
                {
                    Id = p.PostId,
                    // map other properties here
                }),
                Orders = user.Orders.Select(o => new OrderServiceModel
                {
                    Id = o.Id,
                    // map other properties here
                }),
                //Messages = user.
            };

            return profile;
        }


        public async Task<ApplicationUser> GetUserById(string id)
            => await this.db
                         .Users
                         .FindAsync(id);

        public async Task<ApplicationUser> GetUserByUserName(string username)
            => await this.db
                         .Users
                         .FirstAsync(x => x.UserName == username);

        public string GetUserId(string username)
            => this.GetUserByUserName(username)
                   .Result
                   .Id;

        public async Task<List<UserListingServiceModel>> SearchAsync(string searchText)
        {
            if(string.IsNullOrWhiteSpace(searchText))
            {
                return await this.db
                                 .Users
                                 .ProjectTo<UserListingServiceModel>()
                                 .ToListAsync();
            }

            return await this.db
                             .Users
                             .Where(u => u.UserName.Contains(searchText))
                             .ProjectTo<UserListingServiceModel>()
                             .ToListAsync();
        }
    }
}
