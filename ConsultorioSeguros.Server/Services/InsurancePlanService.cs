using AutoMapper;
using ConsultorioSeguros.Server.Data.Repository;
using ConsultorioSeguros.Server.Dto;
using ConsultorioSeguros.Server.Entities;
using ConsultorioSeguros.Server.Interfaces;

namespace ConsultorioSeguros.Server.Services
{
    public class InsurancePlanService
    {
        private readonly IRepository<int, InsurancePlan> _insurancePlanRepository;
        private readonly IMapper _mapper;

        public InsurancePlanService(IMapper mapper, IRepository<int, InsurancePlan> insurancePlanRepository)
        {
            _mapper = mapper;
            _insurancePlanRepository = insurancePlanRepository;
        }

        public async Task<IEnumerable<InsurancePlanDto>> GetAll()
        {
            var insurancePlans = await _insurancePlanRepository.GetAll();
            return _mapper.Map<List<InsurancePlanDto>>(insurancePlans);
        }

        public async Task<InsurancePlanDto> Get(int code)
        {
            var insurancePlan = await _insurancePlanRepository.Get(code);
            return _mapper.Map<InsurancePlanDto>(insurancePlan);
        }

        public async Task<InsurancePlanDto> Add(InsurancePlanInputDto insurancePlanDto)
        {
            var insurancePlan = _mapper.Map<InsurancePlan>(insurancePlanDto);
            await _insurancePlanRepository.Add(insurancePlan);

            return _mapper.Map<InsurancePlanDto>(insurancePlan);
        }

        public async Task<InsurancePlanDto> Update(int id, InsurancePlanInputDto insurancePlanDto)
        {
            var insurancePlan = await _insurancePlanRepository.Get(id);

            if (insurancePlan == null)
            {
                throw new ArgumentException($"No existe un plan de ID {id}");
            }

            insurancePlan.Name = insurancePlanDto.Name;
            insurancePlan.Premium = insurancePlanDto.Premium;
            insurancePlan.Amount = insurancePlanDto.Amount;
            await _insurancePlanRepository.Update(insurancePlan);

            return _mapper.Map<InsurancePlanDto>(insurancePlan);
        }
    }
}
