using GenericRepository.Implementacoes;
using Gerenciador_Registro_de_Pacientes.Interfaces;
using Gerenciador_Registro_de_Pacientes.Models;

namespace Gerenciador_Registro_de_Pacientes.Implementacoes;

public class PacienteJsonRepository : GenericJsonRepository<Paciente>, IPacienteRepository
{
    public PacienteJsonRepository(string v) : base("pacientes.json")
    {
    }

    public IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima)
    {
        DateTime hoje = DateTime.Today;

        return ObterTodos().Where(p =>
        {
            int idade = hoje.Year - p.DataNascimento.Year;
            if (p.DataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade >= idadeMinima && idade <= idadeMaxima;
        });
    }
}