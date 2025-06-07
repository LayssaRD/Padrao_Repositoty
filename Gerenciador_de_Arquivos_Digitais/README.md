# Gerenciador de Arquivos Digitais

## Descrição

Sistema para gerenciar arquivos digitais aplicando o princípio DRY (Don't Repeat Yourself). O repositório específico herda do `GenericJsonRepository`, removendo código duplicado e mantendo apenas métodos especializados.

## Funcionalidades

### Entidade ArquivoDigital

- **Id**: Identificador único (Guid)
- **NomeArquivo**: Nome do arquivo
- **TipoArquivo**: Tipo/extensão do arquivo (PDF, Excel, etc.)
- **TamanhoBytes**: Tamanho em bytes
- **DataUpload**: Data de upload do arquivo

### Repositório Específico

- **ObterPorTipoArquivo**: Filtra arquivos por tipo
- **ObterPorPeriodo**: Filtra por período de upload
- **ObterTamanhoTotalArquivos**: Calcula o tamanho total de todos os arquivos

### Aplicação do Princípio DRY

O `ArquivoDigitalJsonRepository` herda de `GenericJsonRepository<ArquivoDigital>`, reutilizando:

- Funcionalidades básicas de CRUD
- Serialização/deserialização JSON
- Gerenciamento de arquivo de persistência

Implementa apenas métodos específicos para consultas especializadas.

## Como Executar

```bash
cd Gerenciador_de_Arquivos_Digitais
dotnet run
```

## Exemplo de Uso

O programa demonstra:

1. Adição de arquivos de diferentes tipos
2. Listagem de todos os arquivos
3. Filtro por tipo (ex: PDFs)
4. Filtro por período recente
5. Cálculo do tamanho total ocupado
