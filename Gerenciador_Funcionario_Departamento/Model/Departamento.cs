using System;
using Gerenciador_Funcionario_Departamento.Entidade;
namespace Gerenciador_Funcionario_Departamento.Model;

public class Departamento : IEntidade
{
    public Guid Id { get; set; }
    public string NomeDepartamento { get; set; } = string.Empty;
    public string Sigla { get; set; } = string.Empty;
}