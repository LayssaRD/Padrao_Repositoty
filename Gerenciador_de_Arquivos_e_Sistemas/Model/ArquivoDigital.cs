using GenericRepository.Entidade;

namespace Gerenciador_de_Arquivos_e_Sistemas.Model;

public class ArquivoDigital : IEntidade
{
    public Guid Id { get; set; }
    public string NomeArquivo { get; set; } = string.Empty;
    public string TipoArquivo { get; set; } = string.Empty;
    public long TamanhoBytes { get; set; }
    public DateTime DataUpload { get; set; }
}
