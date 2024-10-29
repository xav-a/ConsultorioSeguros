namespace ConsultorioSeguros.Server.Model
{
    public class ClientModel
    {
        // Cédula
        public string IdentificationNumber { get; set; }

        // Nombres
        public string Names { get; set; }

        // Apellidos
        public string LastNames { get; set; }

        // Nombre Completo
        public string FullName => $"{Names} {LastNames}".Trim();

        // Edad
        public int Age { get; set; }

        // Teléfono
        public string PhoneNumber { get; set; }
    }
}
