namespace ConsultorioSeguros.Server.Model
{
    public class InsurancePolicyModel
    {
        // Número de póliza
        public int Number { get; set; }

        public int InsurancePlanId { get; set; }

        public int ClientId { get; set; }
    }
}
