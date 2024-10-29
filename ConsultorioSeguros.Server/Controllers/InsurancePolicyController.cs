using AutoMapper;
using ConsultorioSeguros.Server.Dto;
using ConsultorioSeguros.Server.Entities;
using ConsultorioSeguros.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSeguros.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly ILogger<InsurancePolicyController> _logger;
        private readonly IRepository<int, InsurancePolicy> _insurancePolicyRepository;
        private readonly IMapper _mapper;

        public InsurancePolicyController(
            ILogger<InsurancePolicyController> logger,
            IRepository<int, InsurancePolicy> insurancePolicyRepository,
            IMapper mapper)
        {
            _logger = logger;
            _insurancePolicyRepository = insurancePolicyRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<InsurancePolicyDto> Add(InsurancePolicyInputDto input)
        {
            try
            {
                var policy = new InsurancePolicy()
                {
                    InsurancePlanId = input.InsurancePlanId,
                    ClientId = input.ClientId
                };

                await _insurancePolicyRepository.Add(policy);
                return _mapper.Map<InsurancePolicyDto>(policy);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                _logger.LogError(ex, $"Error in {nameof(InsurancePolicyController)}.{nameof(Add)}");
                return null;
            }
        }

        [HttpDelete]
        public async Task Delete(int policyNumber)
        {
            try
            {
                var policy = await _insurancePolicyRepository.Get(policyNumber);

                if (policy != null)
                {
                    await _insurancePolicyRepository.Delete(policy);
                }
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                _logger.LogError(ex, $"Error in {nameof(InsurancePolicyController)}.{nameof(Add)}");
            }
        }
    }
}
