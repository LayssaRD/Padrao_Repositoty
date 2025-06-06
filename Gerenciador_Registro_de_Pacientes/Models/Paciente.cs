using GenericRepository.Entidade;

namespace Gerenciador_Registro_de_Pacientes.Models;

public class Paciente : IEntidade
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string ContatoEmergencia { get; set; } = string.Empty;
}
