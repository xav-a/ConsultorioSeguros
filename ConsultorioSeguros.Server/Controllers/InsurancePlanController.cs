using ConsultorioSeguros.Server.Dto;
using ConsultorioSeguros.Server.Entities;
using ConsultorioSeguros.Server.Interfaces;
using ConsultorioSeguros.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSeguros.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class InsurancePlanController : ControllerBase
    {
        private readonly ILogger<InsurancePlanController> _logger;
        private readonly InsurancePlanService _insurancePlanService;

        public InsurancePlanController(ILogger<InsurancePlanController> logger, InsurancePlanService insurancePlanService)
        {
            _logger = logger;
            _insurancePlanService = insurancePlanService;
        }

        [HttpGet]
        public async Task<IEnumerable<InsurancePlanDto>> Get()
        {
            return await _insurancePlanService.GetAll();

        }

        [HttpGet("{id}")]
        public async Task<InsurancePlanDto> Get(int id)
        {
            return await _insurancePlanService.Get(id);
        }

        [HttpPost]
        public async Task<InsurancePlanDto> Add(InsurancePlanInputDto insurancePlanDto)
        {
            try
            {
                return await _insurancePlanService.Add(insurancePlanDto);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                _logger.LogError(ex, $"Error in {nameof(InsurancePlanController)}.{nameof(Add)}");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<InsurancePlanDto> Update(int id, InsurancePlanInputDto insurancePlanDto)
        {
            try
            {
                return await _insurancePlanService.Update(id, insurancePlanDto);
            }
            catch (ArgumentException ex)
            {
                HttpContext.Response.StatusCode = 404;
                return null;
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                _logger.LogError(ex, $"Error in {nameof(InsurancePlanController)}.{nameof(Get)}");
                return null;
            }
        }
    }
}
