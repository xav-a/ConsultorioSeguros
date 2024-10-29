using AutoMapper;
using ConsultorioSeguros.Server.Data.Repository;
using ConsultorioSeguros.Server.Dto;
using ConsultorioSeguros.Server.Entities;
using ConsultorioSeguros.Server.Interfaces;

namespace ConsultorioSeguros.Server.Services
{
    public class ClientService
    {

        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            var clients = await _clientRepository.GetAll();
            return _mapper.Map<List<ClientDto>>(clients);
        }

        public async Task<ClientDto> Get(int id)
        {
            var client = await _clientRepository.Get(id);
            return _mapper.Map<ClientDto>(client);
        }
        
        public async Task<ClientDto> GetByIdNumber(string identificationNumber)
        {
            var client = await _clientRepository.GetByIdNumber(identificationNumber);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> Add(ClientInputDto clientDto)
        {
            var client = new Client()
            {
                Age = clientDto.Age,
                IdentificationNumber = clientDto.IdentificationNumber,
                LastNames = clientDto.LastNames,
                Names = clientDto.Names,
                PhoneNumber = clientDto.PhoneNumber
            };

            await _clientRepository.Add(client);

            return _mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> Update(int id, ClientInputDto clientDto)
        {
            var client = await _clientRepository.Get(id);

            if (client == null)
            {
                throw new ArgumentException($"No existe el cliente que está intentando actualizar");
            }

            client.Names = clientDto.Names;
            client.LastNames = clientDto.LastNames;
            client.Age = clientDto.Age;
            client.PhoneNumber = clientDto.PhoneNumber;
            await _clientRepository.Update(client);

            return _mapper.Map<ClientDto>(client);
        }


        public async Task<int> Add(IEnumerable<ClientInputDto> clientDtos)
        {
            if (clientDtos == null || !clientDtos.Any()) return 0;

            // Validar que los números de documento no estén duplicados
            var docNumbers = clientDtos.Select(c => c.IdentificationNumber);
            if (docNumbers.Count() != docNumbers.Distinct().Count())
            {
                throw new ArgumentException("No puede agregar el mismo asegurado más de una vez");
            }

            var clients = _mapper.Map<List<Client>>(clientDtos);
            return await _clientRepository.BulkAdd(clients);
        }
    }
}
