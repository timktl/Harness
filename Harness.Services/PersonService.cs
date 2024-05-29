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
            try
            {
                var person = await _personRepository.GetPersonById(id);
                return _mapper.Map<PersonDto>(person);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("An error occurred in the repository layer while fetching Person.", ex);
            }            
        }

        public async Task AddPerson(PersonDto personDto)
        {
            if (personDto == null)
            {
                throw new ArgumentNullException(nameof(personDto));
            }
            else
            {
                try
                {
                    var person = _mapper.Map<Person>(personDto);
                    await _personRepository.AddPerson(person);
                }
                catch (RepositoryException ex)
                {
                    throw new ServiceException("An error occurred in the repository layer while adding Person.", ex);
                }
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
                try
                {
                    var person = _mapper.Map<Person>(personDto);
                    await _personRepository.UpdatePerson(person);
                }
                catch(RepositoryException ex)
                {
                    throw new ServiceException("An error occurred in the repository layer while updating Person.", ex);
                }
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
                try
                {
                    await _personRepository.DeletePerson(id);
                }
                catch (RepositoryException ex)
                {
                    throw new ServiceException("An error occurred in the repository layer while deleting Person.", ex);
                }
            }
        }
    }
}

public class ServiceException : Exception
{
    public ServiceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}