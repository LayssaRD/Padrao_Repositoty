using GenericRepository.Interfaces;
using Sistema_Reservas_Hotel.Entidades;

namespace Sistema_Reservas_Hotel.Interfaces;

public interface IReservaHotelRepository : IRepository<ReservaHotel>
{
    List<ReservaHotel> ObterPorStatus(StatusReserva status);
    List<ReservaHotel> ObterReservasAtivas();
    List<ReservaHotel> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
    List<ReservaHotel> ObterPorQuarto(int numeroQuarto);
    decimal ObterReceitaTotal();
    int ObterQuantidadePorStatus(StatusReserva status);
} 