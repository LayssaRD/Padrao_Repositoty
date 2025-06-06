# ATIVIDADE SOBRE PADRÃO REPOSITORY – Programação Orientada a Objetos (POO)

**Alunos:** João Pedro Z. S, Layssa Alves, Vitor Paladini

## Objetivo

Esta Atividade Prática tem como objetivo aplicar o **Padrão Repository** utilizando conceitos de **Programação Orientada a Objetos (POO)** em **C#**, com foco na persistência de dados em arquivos JSON. A atividade promove a separação entre lógica de negócios e acesso a dados por meio de repositórios específicos e genéricos, além de explorar conceitos como **associação entre objetos**, **herança**, **polimorfismo**, e **consultas especializadas**.

---

## Exercícios Desenvolvidos

### 1. Gerenciador Catálogo de Produtos
- Entidade `Produto` com propriedades como `Nome`, `Descrição`, `Preço` e `Estoque`.
- Interface `IProdutoRepository` com métodos CRUD.
- Repositório `ProdutoJsonRepository` serializa para `produtos.json`.

### 2. Biblioteca de Músicas com Repositório Genérico
- Entidade `Musica` com propriedades como `Título`, `Artista`, `Álbum`, `Duração`.
- Uso de `GenericJsonRepository` com persistência automática em `musicas.json`.

### 3. Catálogo de Filmes com Filtro por Gênero
- Entidade `Filme` com propriedades `Título`, `Diretor`, `AnoLancamento`, `Gênero`.
- Interface `IFilmeRepository` com método `ObterPorGenero`.
- Repositório especializado `FilmeJsonRepository`.

### 4. Sistema de Funcionários e Departamentos
- Entidades `Funcionario` e `Departamento` com relacionamento via `DepartamentoId`.
- Repositórios genéricos para ambas as entidades.
- Associação representada por chave de referência.

### 5. Registro de Pacientes com Filtro por Faixa Etária
- Entidade `Paciente` com `DataNascimento` e `ContatoEmergencia`.
- Interface `IPacienteRepository` com método `ObterPorFaixaEtaria`.
- Repositório `PacienteJsonRepository` com lógica de cálculo de idade.

### 6. Inventário de Equipamentos de TI (Repositório em Memória)
- Entidade `EquipamentoTI` com `Tipo`, `Número de Série`, `Data de Aquisição`.
- Repositório `InMemoryEquipamentoTIRepository` com lista interna em memória.
- Sem uso de arquivos JSON.

### 7. Sistema de Pedidos de Restaurante com Herança
- Classe abstrata `ItemCardapio` com subclasses `Prato` e `Bebida`.
- Uso de `GenericJsonRepository` para armazenar itens variados.
- Explora serialização de hierarquias.

### 8. Gerenciador de Arquivos Digitais
- Entidade `ArquivoDigital` com `Nome`, `Tipo`, `Tamanho` e `DataUpload`.
- Refatoração do repositório para herdar de `GenericJsonRepository`.

### 9. Sistema de Reservas de Hotel com Filtro por Status
- Entidade `ReservaHotel` com enum `StatusReserva`.
- Interface `IReservaHotelRepository` com método `ObterPorStatus`.
- Repositório especializado `ReservaHotelJsonRepository`.

### 10. Plataforma de Cursos Online com Lógica de Negócio
- Entidade `CursoOnline`.
- Interface `ICursoOnlineRepository` e repositório correspondente.
- Camada de serviço `CatalogoCursosService` com regras como verificação de duplicidade.

---

## Como Executar

1. Clone o repositório:
```bash
git clone https://github.com/LayssaRD/Padrao_Repositoty
```

2. Navegue até o diretório de qualquer exercício:
```bash
cd Gerenciador_Biblioteca_de_Musica
```

3. Execute o projeto:
```bash
dotnet run
```

---

## Organização do Repositório

Cada exercício está organizado em uma pasta separada:

```
├── GenericRepository/
├── Gerenciador_Biblioteca_de_Musica/
├── Gerenciador_Catalogo_Filmes/
├── Gerenciador_Catalogo_Produtos/
├── Gerenciador_de_Arquivos_Digitais/
├── Gerenciador_Funcionario_Departamento/
├── Gerenciador_Registro_de_Pacientes/
├── 
├── 
├──
├──
```

---

## Observações

- Todos os sistemas utilizam **validações rigorosas** para garantir a integridade das informações.
- As implementações aplicam **encapsulamento**, **associação**, **herança**, **composição** e **polimorfismo** conforme o contexto de cada problema.
