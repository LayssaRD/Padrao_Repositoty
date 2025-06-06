using GenericRepository.Interfaces;
using Gerenciador_Registro_de_Pacientes.Models;

namespace Gerenciador_Registro_de_Pacientes.Interfaces;

public interface IPacienteRepository: IRepository<Paciente>
{
    IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima);
}
