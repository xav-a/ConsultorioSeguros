using ConsultorioSeguros.Server.Model;

namespace ConsultorioSeguros.Server.Dto
{
    public class ClientDto : ClientModel
    {
        public int Id { get; set; }

        public IEnumerable<InsurancePlanDto> InsurancePlans { get; set; } = new List<InsurancePlanDto>();
    }
}
