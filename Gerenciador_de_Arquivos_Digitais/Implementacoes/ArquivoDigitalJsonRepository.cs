using GenericRepository.Implementacoes;
using Gerenciador_de_Arquivos_Digitais.Entidades;
using Gerenciador_de_Arquivos_Digitais.Interfaces;

namespace Gerenciador_de_Arquivos_Digitais.Implementacoes;

public class ArquivoDigitalJsonRepository : GenericJsonRepository<ArquivoDigital>, IArquivoDigitalRepository
{
    public ArquivoDigitalJsonRepository(string? caminhoArquivo = null) 
        : base(caminhoArquivo ?? "arquivos_digitais.json")
    {
    }

    public List<ArquivoDigital> ObterPorTipoArquivo(string tipoArquivo)
    {
        return ObterTodos()
            .Where(arquivo => arquivo.TipoArquivo.Equals(tipoArquivo, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<ArquivoDigital> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
    {
        return ObterTodos()
            .Where(arquivo => arquivo.DataUpload >= dataInicio && arquivo.DataUpload <= dataFim)
            .OrderBy(arquivo => arquivo.DataUpload)
            .ToList();
    }

    public long ObterTamanhoTotalArquivos()
    {
        return ObterTodos().Sum(arquivo => arquivo.TamanhoBytes);
    }
} 