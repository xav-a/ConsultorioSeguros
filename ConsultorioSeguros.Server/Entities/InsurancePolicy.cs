using ConsultorioSeguros.Server.Model;

namespace ConsultorioSeguros.Server.Entities
{
    public class InsurancePolicy : InsurancePolicyModel
    {

        public virtual InsurancePlan InsurancePlan { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;
    }
}
