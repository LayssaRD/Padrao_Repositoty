# Plataforma de Cursos Online

## Descrição

Sistema completo de gestão de cursos online demonstrando o uso de camada de serviço para implementar regras de negócio. O repositório é usado via injeção de dependência, separando claramente a lógica de persistência da lógica de negócios.

## Funcionalidades

### Entidade CursoOnline

- **Id**: Identificador único (Guid)
- **Titulo**: Nome do curso
- **Descricao**: Descrição detalhada
- **Instrutor**: Nome do instrutor
- **Categoria**: Categoria do curso (Programação, Design, etc.)
- **Preco**: Valor do curso
- **CargaHoraria**: Duração em horas
- **Nivel**: Nível de dificuldade (Iniciante, Intermediário, Avançado)
- **DataCriacao**: Data de criação do curso
- **DataPublicacao**: Data de publicação (nullable)
- **Ativo**: Se o curso está ativo
- **UrlImagem**: URL da imagem do curso (opcional)
- **Tags**: Lista de tags para busca
- **MaximoAlunos**: Limite de alunos
- **AlunosMatriculados**: Quantidade atual de alunos

### Repositório Específico

- **ObterPorCategoria**: Filtra cursos por categoria
- **ObterPorInstrutor**: Lista cursos de um instrutor
- **ObterPorNivel**: Filtra por nível de dificuldade
- **ObterCursosPublicados**: Retorna apenas cursos publicados
- **ObterCursosComVagas**: Cursos com vagas disponíveis
- **ObterPorFaixaPreco**: Filtra por faixa de preço
- **ObterPorTitulo**: Busca curso pelo título exato
- **ExisteCursoComTitulo**: Verifica se já existe curso com mesmo título

### Camada de Serviço (CatalogoCursosService)

Implementa regras de negócio complexas:

#### RegistrarCurso

- Validações obrigatórias (título, instrutor)
- Verificação de duplicatas por título
- Validação de preço não negativo
- Validação de carga horária positiva
- Validação de máximo de alunos
- Definição automática de data de criação

#### PublicarCurso

- Verificação se curso existe
- Validação se já está publicado
- Validações para publicação (descrição, categoria)
- Ativação e definição de data de publicação

#### Outras Funcionalidades

- **ObterCatalogoPublico**: Lista apenas cursos publicados
- **PesquisarCursos**: Busca por título, descrição ou tags
- **MatricularAluno**: Gerencia matrículas com validações
- **CalcularReceitaTotal**: Calcula receita baseada em matrículas
- **ObterEstatisticasPorCategoria**: Relatórios por categoria

## Arquitetura

### Separação de Responsabilidades

- **Repositório**: Persistência e consultas básicas
- **Serviço**: Lógica de negócio e validações
- **Entidade**: Modelo de dados e propriedades calculadas

### Injeção de Dependência

```csharp
ICursoOnlineRepository repository = new CursoOnlineJsonRepository();
CatalogoCursosService catalogoService = new CatalogoCursosService(repository);
```

## Como Executar

```bash
cd Plataforma_Cursos_Online
dotnet run
```

## Exemplo de Uso

O programa demonstra:

1. Registro de cursos com validações
2. Tentativa de registro de curso duplicado
3. Publicação de cursos
4. Catálogo público
5. Pesquisa de cursos
6. Simulação de matrículas
7. Relatórios de receita e estatísticas
8. Consultas por categoria e disponibilidade
