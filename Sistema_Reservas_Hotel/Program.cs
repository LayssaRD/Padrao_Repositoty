using Sistema_Reservas_Hotel.Entidades;
using Sistema_Reservas_Hotel.Implementacoes;
using Sistema_Reservas_Hotel.Interfaces;

namespace Sistema_Reservas_Hotel;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE RESERVAS DE HOTEL ===");
        
        IReservaHotelRepository repository = new ReservaHotelJsonRepository();
        
        // Adicionando reservas de exemplo
        var reserva1 = new ReservaHotel
        {
            NomeHospede = "João Silva",
            EmailHospede = "joao@email.com",
            TelefoneHospede = "(11) 98765-4321",
            DataCheckIn = DateTime.Now.AddDays(5),
            DataCheckOut = DateTime.Now.AddDays(8),
            NumeroQuarto = 101,
            TipoQuarto = "Standard",
            ValorTotal = 450.00m,
            Status = StatusReserva.Confirmada,
            DataReserva = DateTime.Now
        };
        
        var reserva2 = new ReservaHotel
        {
            NomeHospede = "Maria Santos",
            EmailHospede = "maria@email.com",
            TelefoneHospede = "(11) 91234-5678",
            DataCheckIn = DateTime.Now.AddDays(1),
            DataCheckOut = DateTime.Now.AddDays(3),
            NumeroQuarto = 205,
            TipoQuarto = "Suite",
            ValorTotal = 800.00m,
            Status = StatusReserva.CheckIn,
            DataReserva = DateTime.Now.AddDays(-5)
        };
        
        var reserva3 = new ReservaHotel
        {
            NomeHospede = "Pedro Oliveira",
            EmailHospede = "pedro@email.com",
            TelefoneHospede = "(11) 95555-1234",
            DataCheckIn = DateTime.Now.AddDays(-3),
            DataCheckOut = DateTime.Now.AddDays(-1),
            NumeroQuarto = 150,
            TipoQuarto = "Deluxe",
            ValorTotal = 600.00m,
            Status = StatusReserva.CheckOut,
            DataReserva = DateTime.Now.AddDays(-10)
        };
        
        repository.Adicionar(reserva1);
        repository.Adicionar(reserva2);
        repository.Adicionar(reserva3);
        
        // Demonstrando funcionalidades
        Console.WriteLine("\n--- TODAS AS RESERVAS ---");
        foreach (var reserva in repository.ObterTodos())
        {
            Console.WriteLine(reserva);
        }
        
        Console.WriteLine("\n--- RESERVAS CONFIRMADAS ---");
        foreach (var reserva in repository.ObterPorStatus(StatusReserva.Confirmada))
        {
            Console.WriteLine(reserva);
        }
        
        Console.WriteLine("\n--- RESERVAS ATIVAS (CHECK-IN OU CONFIRMADAS) ---");
        foreach (var reserva in repository.ObterReservasAtivas())
        {
            Console.WriteLine(reserva);
        }
        
        Console.WriteLine($"\n--- RECEITA TOTAL: R$ {repository.ObterReceitaTotal():F2} ---");
        
        Console.WriteLine("\n--- ESTATÍSTICAS POR STATUS ---");
        foreach (StatusReserva status in Enum.GetValues<StatusReserva>())
        {
            int quantidade = repository.ObterQuantidadePorStatus(status);
            if (quantidade > 0)
            {
                Console.WriteLine($"{status}: {quantidade} reserva(s)");
            }
        }
        
        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
} 