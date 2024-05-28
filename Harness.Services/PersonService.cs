using AutoMapper;
using Harness.Data.Interface;
using Harness.Models.Dto;
using Harness.Models.Model;
using Harness.Services.Interface;
using System;

namespace Harness.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonDto> GetPersonById(int id)
        {
            var person = await _personRepository.GetPersonById(id);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task AddPerson(PersonDto personDto)
        {
            if (personDto == null)
            {
                throw new ArgumentNullException(nameof(personDto));
            }
            else
            {
                var person = _mapper.Map<Person>(personDto);
                await _personRepository.AddPerson(person);
            }
        }

        public async Task UpdatePerson(PersonDto personDto)
        {
            if (personDto == null)
            {
                throw new ArgumentNullException(nameof(personDto));
            }
            else
            {
                var person = _mapper.Map<Person>(personDto);
                 await _personRepository.UpdatePerson(person);
            }
        }
        public async Task DeletePerson(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                await _personRepository.DeletePerson(id);
            }
        }

    }
}
