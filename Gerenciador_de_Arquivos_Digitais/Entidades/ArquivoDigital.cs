using GenericRepository.Entidade;

namespace Gerenciador_de_Arquivos_Digitais.Entidades;

public class ArquivoDigital : IEntidade
{
    public Guid Id { get; set; }
    public string NomeArquivo { get; set; } = string.Empty;
    public string TipoArquivo { get; set; } = string.Empty;
    public long TamanhoBytes { get; set; }
    public DateTime DataUpload { get; set; }

    public override string ToString()
    {
        return $"Nome: {NomeArquivo}, Tipo: {TipoArquivo}, Tamanho: {TamanhoBytes} bytes, Data: {DataUpload:dd/MM/yyyy HH:mm}";
    }
} 