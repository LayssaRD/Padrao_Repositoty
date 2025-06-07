using GenericRepository.Entidade;

namespace Sistema_Reservas_Hotel.Entidades;

public class ReservaHotel : IEntidade
{
    public Guid Id { get; set; }
    public string NomeHospede { get; set; } = string.Empty;
    public string EmailHospede { get; set; } = string.Empty;
    public string TelefoneHospede { get; set; } = string.Empty;
    public DateTime DataCheckIn { get; set; }
    public DateTime DataCheckOut { get; set; }
    public int NumeroQuarto { get; set; }
    public string TipoQuarto { get; set; } = string.Empty;
    public decimal ValorTotal { get; set; }
    public StatusReserva Status { get; set; }
    public DateTime DataReserva { get; set; }
    public string? Observacoes { get; set; }

    public int DiasEstadia => (DataCheckOut - DataCheckIn).Days;

    public override string ToString()
    {
        return $"Reserva: {NomeHospede}, Quarto: {NumeroQuarto}, " +
               $"Check-in: {DataCheckIn:dd/MM/yyyy}, Check-out: {DataCheckOut:dd/MM/yyyy}, " +
               $"Status: {Status}, Valor: R$ {ValorTotal:F2}";
    }
} 