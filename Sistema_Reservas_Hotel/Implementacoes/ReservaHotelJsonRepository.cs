using GenericRepository.Implementacoes;
using Sistema_Reservas_Hotel.Entidades;
using Sistema_Reservas_Hotel.Interfaces;

namespace Sistema_Reservas_Hotel.Implementacoes;

public class ReservaHotelJsonRepository : GenericJsonRepository<ReservaHotel>, IReservaHotelRepository
{
    public ReservaHotelJsonRepository(string? caminhoArquivo = null) 
        : base(caminhoArquivo ?? "reservas_hotel.json")
    {
    }

    public List<ReservaHotel> ObterPorStatus(StatusReserva status)
    {
        return ObterTodos()
            .Where(reserva => reserva.Status == status)
            .OrderBy(reserva => reserva.DataCheckIn)
            .ToList();
    }

    public List<ReservaHotel> ObterReservasAtivas()
    {
        var statusAtivos = new[] { StatusReserva.Confirmada, StatusReserva.CheckIn };
        return ObterTodos()
            .Where(reserva => statusAtivos.Contains(reserva.Status))
            .OrderBy(reserva => reserva.DataCheckIn)
            .ToList();
    }

    public List<ReservaHotel> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
    {
        return ObterTodos()
            .Where(reserva => reserva.DataCheckIn >= dataInicio && reserva.DataCheckOut <= dataFim)
            .OrderBy(reserva => reserva.DataCheckIn)
            .ToList();
    }

    public List<ReservaHotel> ObterPorQuarto(int numeroQuarto)
    {
        return ObterTodos()
            .Where(reserva => reserva.NumeroQuarto == numeroQuarto)
            .OrderBy(reserva => reserva.DataCheckIn)
            .ToList();
    }

    public decimal ObterReceitaTotal()
    {
        var statusRealizados = new[] { StatusReserva.CheckOut, StatusReserva.CheckIn };
        return ObterTodos()
            .Where(reserva => statusRealizados.Contains(reserva.Status))
            .Sum(reserva => reserva.ValorTotal);
    }

    public int ObterQuantidadePorStatus(StatusReserva status)
    {
        return ObterTodos().Count(reserva => reserva.Status == status);
    }
} 