# Sistema de Reservas de Hotel com Status

## Descrição

Sistema completo de gerenciamento de reservas de hotel utilizando enum para representar diferentes status da reserva. Demonstra consultas especializadas baseadas em status e cálculos de receita.

## Funcionalidades

### Enum StatusReserva

- **Pendente**: Reserva criada mas não confirmada
- **Confirmada**: Reserva confirmada pelo hotel
- **CheckIn**: Hóspede fez check-in
- **CheckOut**: Hóspede fez check-out
- **Cancelada**: Reserva cancelada
- **NoShow**: Hóspede não compareceu

### Entidade ReservaHotel

- **Id**: Identificador único (Guid)
- **NomeHospede**: Nome do hóspede
- **EmailHospede**: Email para contato
- **TelefoneHospede**: Telefone para contato
- **DataCheckIn**: Data prevista de entrada
- **DataCheckOut**: Data prevista de saída
- **NumeroQuarto**: Número do quarto reservado
- **TipoQuarto**: Tipo do quarto (Standard, Suite, Deluxe)
- **ValorTotal**: Valor total da reserva
- **Status**: Status atual da reserva (enum)
- **DataReserva**: Data em que a reserva foi feita
- **Observacoes**: Observações adicionais (opcional)

### Repositório Específico

- **ObterPorStatus**: Filtra reservas por status específico
- **ObterReservasAtivas**: Retorna reservas confirmadas ou com check-in
- **ObterPorPeriodo**: Filtra por período de estadia
- **ObterPorQuarto**: Consulta histórico de um quarto específico
- **ObterReceitaTotal**: Calcula receita de reservas efetivadas
- **ObterQuantidadePorStatus**: Conta reservas por status

## Como Executar

```bash
cd Sistema_Reservas_Hotel
dotnet run
```

## Exemplo de Uso

O programa demonstra:

1. Criação de reservas com diferentes status
2. Consulta de reservas por status específico
3. Listagem de reservas ativas
4. Cálculo da receita total
5. Estatísticas por status
6. Funcionalidades de relatório gerencial
