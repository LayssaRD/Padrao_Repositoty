using System;
using Gerenciador_Funcionario_Departamento.Entidade;
namespace Gerenciador_Funcionario_Departamento.Model;

public class Funcionario : IEntidade
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public Guid DepartamentoId { get; set; }
}
