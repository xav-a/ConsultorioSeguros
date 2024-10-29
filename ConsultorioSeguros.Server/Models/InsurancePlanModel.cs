namespace ConsultorioSeguros.Server.Model
{
    public class InsurancePlanModel
    {
        // Código
        public int Code { get; set; }

        // Nombre
        public string Name { get; set; }

        // Suma Asegurada
        public decimal Amount  { get; set; }

        // Prima
        public decimal Premium { get; set; }
    }
}
