using System;
using GenericRepository.Implementacoes;
using Gerenciador_de_Arquivos_e_Sistemas.Interfaces;
using Gerenciador_de_Arquivos_e_Sistemas.Model;


public class ArquivoDigitalJsonRepository: GenericJsonRepository<ArquivoDigital>, IArquivoDigitalRepository
{
    public ArquivoDigitalJsonRepository() : base("arquivos.json")
    {
    }

    public IEnumerable<ArquivoDigital> ObterPorTipo(string tipoArquivo)
    {
        return ObterTodos().Where(a => a.TipoArquivo.Equals(tipoArquivo, StringComparison.OrdinalIgnoreCase));
    }
}