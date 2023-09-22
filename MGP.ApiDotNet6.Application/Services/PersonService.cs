using AutoMapper;
using MGP.ApiDotNet6.Application.Dtos;
using MGP.ApiDotNet6.Application.Services.Interfaces;
using MGP.ApiDotNet6.Application.Validations;
using MGP.ApiDotNet6.Domain.Entities;
using MGP.ApiDotNet6.Domain.Repositories;
using System.Collections.Generic;

namespace MGP.ApiDotNet6.Application.Services
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
        public async Task<ResultService<PersonDto>> CreateAsync(PersonDto personDto)
        {
            if(personDto == null)
            {
                return ResultService.Fail<PersonDto>("Objeto deve ser informado");
            }

            var result = new PersonValidator().Validate(personDto);

            if(!result.IsValid) return ResultService.RequestError<PersonDto>("Problemas de validação ", result);

            Person person = _mapper.Map<Person>(personDto);

            var data = await _personRepository.CreateAsync(person);

            return ResultService.Ok<PersonDto>(_mapper.Map<PersonDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return ResultService.Fail("Pessoa não encontrada");

            await _personRepository.DeleteAsync(id);
            return ResultService.Ok("Registro excluído.");
        }

        public async Task<ResultService<ICollection<PersonDto>>> GetAllAsync()
        {
            var collection = await _personRepository.GetAllAsync();

           //MOCK
         /*   List<PersonDto> collection = new List<PersonDto>
            {
                new PersonDto()
                {
                    Id = 1,
                    Document = "674412390388",
                    Name = "Matheus Gustavo",
                    Phone = "8585858585"
                },
                new PersonDto()
                {
                    Id = 2,
                    Document = "605412390388",
                    Name = "Joao Paulo",
                    Phone = "8585858585"
                },
                new PersonDto()
                {
                    Id = 3,
                    Document = "904412390388",
                    Name = "Gustavo Pereira",
                    Phone = "8585858585"
                }
            };*/
          //  if(collection.Count <= 0)
               // return ResultService.Fail<ICollection<PersonDto>>("Nenhum registro encontrado");

            return ResultService.Ok<ICollection<PersonDto>>(_mapper.Map<ICollection<PersonDto>>(collection));
           
        }

        public async Task<ResultService<PersonDto>> GetByIdAsync(int id)
        {
            var collection = await _personRepository.GetByIdAsync(id);
           /* var collection = new PersonDto()
            {
                Id = 1,
                Document = "674412390388",
                Name = "Matheus Gustavo",
                Phone = "8585858585"
            };*/
           // if(collection == null)
               // return ResultService.Fail<PersonDto>("Pessoa não encontrada.");

            return ResultService.Ok<PersonDto>(_mapper.Map<PersonDto>(collection));
        }

        public async Task<ResultService<PersonDto>> UpdateAsync(PersonDto personDto)
        {
            if (personDto == null)
            {
                return ResultService.Fail<PersonDto>("Objeto deve ser informado");
            }

            var result = new PersonValidator().Validate(personDto);

            if (!result.IsValid) return ResultService.RequestError<PersonDto>("Problemas de validação ", result);

            var person = await _personRepository.GetByIdAsync(personDto.Id);
            if (person == null)
                return (ResultService<PersonDto>)ResultService.Fail("Pessoa não encontrada.");

             person = _mapper.Map<PersonDto,Person>(personDto,person);

            var data = await _personRepository.UpdateAsync(person);

            return ResultService.Ok<PersonDto>(_mapper.Map<PersonDto>(data));
        }
       
    }
}
