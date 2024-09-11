namespace SaldoVacaciones.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        // ID del puesto que ocupa el empleado
        public int IdPuesto { get; set; }

        // Documento de identidad del empleado
        public required string ValorDocumentoIdentidad { get; set; }

        // Nombre completo del empleado
        public required string Nombre { get; set; }

        // Fecha de contratación, ahora usando DateTime
        public DateTime FechaContratacion { get; set; }

        // Saldo de vacaciones del empleado
        public short SaldoVacaciones { get; set; }

        // Estado de actividad del empleado
        public bool EsActivo { get; set; }
    }
}
