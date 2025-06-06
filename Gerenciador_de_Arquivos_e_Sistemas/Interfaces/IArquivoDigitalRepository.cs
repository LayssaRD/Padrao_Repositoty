using GenericRepository.Interfaces;
using Gerenciador_de_Arquivos_e_Sistemas.Model;

namespace Gerenciador_de_Arquivos_e_Sistemas.Interfaces;

public interface IArquivoDigitalRepository: IRepository<ArquivoDigital>
{
    IEnumerable<ArquivoDigital> ObterPorTipo(string tipoArquivo);
}