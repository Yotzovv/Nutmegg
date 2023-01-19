using Market.Common.Mapping;
using Market.Data.Models;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;

namespace Market.Services.Model
{
    public class UserProfileServiceModel : IMapFrom<Post>, IHaveCustomMapping
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Area { get; set; }

        public byte[] ProfilePicture { get; set; }

        public double Prestige { get; set; }

        public IEnumerable<ProductListingServiceModel> Posts { get; set; }

        public IEnumerable<OrderServiceModel> Orders { get; set; }

        public IEnumerable<Message> Messages { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<ApplicationUser, UserProfileServiceModel>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.IsEmailConfirmed, opt => opt.MapFrom(s => s.EmailConfirmed))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber));
        }
    }
}
