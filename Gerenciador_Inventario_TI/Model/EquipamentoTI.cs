using System;
using GenericRepository.Entidade;
namespace Gerenciador_Inventario_TI.Model;

public class EquipamentoTI : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeEquipamento { get; set; } = string.Empty;
    public string TipoEquipamento { get; set; } = string.Empty;
    public string NumeroSerie { get; set; }= string.Empty;
    public DateTime DataAquisicao { get; set; }
}