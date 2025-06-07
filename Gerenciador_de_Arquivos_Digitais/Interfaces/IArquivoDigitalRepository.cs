using GenericRepository.Interfaces;
using Gerenciador_de_Arquivos_Digitais.Entidades;

namespace Gerenciador_de_Arquivos_Digitais.Interfaces;

public interface IArquivoDigitalRepository : IRepository<ArquivoDigital>
{
    List<ArquivoDigital> ObterPorTipoArquivo(string tipoArquivo);
    List<ArquivoDigital> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
    long ObterTamanhoTotalArquivos();
} 