using ConsultorioSeguros.Server.Model;

namespace ConsultorioSeguros.Server.Entities
{
    public class Client : ClientModel
    {
        public int Id { get; set; }

        public virtual ICollection<InsurancePlan> InsurancePlans { get; } = new List<InsurancePlan>();
    }
}
