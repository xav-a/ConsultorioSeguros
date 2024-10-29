using ConsultorioSeguros.Server.Dto;
using ConsultorioSeguros.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSeguros.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ClientService _clientService;

        public ClientController(ILogger<ClientController> logger, ClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientDto>> Get()
        {
            return await _clientService.GetAll();
            
        }

        [HttpGet("{id}")]
        public async Task<ClientDto> Get(int id)
        {
            return await _clientService.Get(id);
        }

        [HttpGet("Document/{identificationNumber}")]
        public async Task<ClientDto> GetByIdNumber(string identificationNumber)
        {
            return await _clientService.GetByIdNumber(identificationNumber);
        }

        [HttpPost]
        public async Task<ClientDto> Add(ClientInputDto clientDto)
        {
            try
            {
                return await _clientService.Add(clientDto);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                _logger.LogError(ex, $"Error in {nameof(ClientController)}.{nameof(Add)}");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<ClientDto> Update(int id, ClientInputDto clientDto)
        {
            try
            {
                return await _clientService.Update(id, clientDto);
            }
            catch (ArgumentException ex)
            {
                HttpContext.Response.StatusCode = 404;
                return null;
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                _logger.LogError(ex, $"Error in {nameof(ClientController)}.{nameof(Get)}");
                return null;
            }   
        }

        [HttpPost("Bulk")]
        public async Task<int> Add(IEnumerable<ClientInputDto> clientDtos)
        {
            try
            {
                var total = await _clientService.Add(clientDtos);
                if (total == -1)
                {
                    HttpContext.Response.StatusCode = 400;
                }

                return -1;

            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                _logger.LogError(ex, $"Error in {nameof(ClientController)}.{nameof(Add)}\\bulk");
                return -1;
            }
        }
    }
}
