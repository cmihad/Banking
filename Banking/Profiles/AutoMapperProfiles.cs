using AutoMapper;
using Banking.Models;

namespace Banking.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {

            CreateMap<CreateNewAccountDto, Account>();
        }
    }
}
