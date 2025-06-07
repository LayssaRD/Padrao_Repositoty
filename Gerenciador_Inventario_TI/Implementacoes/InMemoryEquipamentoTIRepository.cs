using System;
using Gerenciador_Inventario_TI.Model;
using Gerenciador_Inventario_TI.Interfaces;
namespace Gerenciador_Inventario_TI.Implementacoes;

 public class InMemoryEquipamentoTIRepository : IEquipamentoTIRepository
    {
        private readonly List<EquipamentoTI> _equipamentos = new();

        public void Adicionar(EquipamentoTI entidade)
        {
            _equipamentos.Add(entidade);
        }

        public List<EquipamentoTI> ObterTodos()
        {
            return _equipamentos;
        }

        public EquipamentoTI? ObterPorId(Guid id)
        {
            return _equipamentos.FirstOrDefault(e => e.Id == id);
        }

        public bool Remover(Guid id)
        {
            var equipamento = ObterPorId(id);
            if (equipamento != null)
            {
                _equipamentos.Remove(equipamento);
                return true;
            }
            return false;
        }
    }