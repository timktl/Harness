using AutoMapper;
using Harness.Models.Dto;
using Harness.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness.Models.MappingProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile() 
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
