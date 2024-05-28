using Harness.Models.Dto;
using Harness.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harness.Services.Interface
{
    public interface IPersonService
    {
        Task<PersonDto> GetPersonById(int id);
        Task AddPerson(PersonDto personDto);
        Task UpdatePerson(PersonDto personDto);
        Task DeletePerson(int id);
    }
}
