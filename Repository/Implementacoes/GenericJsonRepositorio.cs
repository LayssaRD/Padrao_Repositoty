using System;
using Repository.Entidade;
using Repository.Interfaces;
using System.Text.Json;

namespace Repository.Implementacoes;

public class GenericJsonRepositorio<T> : IRepositorio<T> where T : class, IEntidade
{
    private readonly string _caminhoArquivo;
    private List<T> _entidades;

    public GenericJsonRepositorio(string? caminhoArquivo = null)
    {
        _caminhoArquivo = caminhoArquivo ?? $"{typeof(T).Name.ToLower()}s.json";
        _entidades = CarregarDoArquivo();
    }
    public void Adicionar(T entidade)
    {
        if (entidade.Id == Guid.Empty) entidade.Id = Guid.NewGuid();
        if (_entidades.Any(e => e.Id == entidade.Id))
        {
            Console.WriteLine($"Entidade {typeof(T).Name} ID {entidade.Id} já existe.");
            return;
        }
        _entidades.Add(entidade);
        SalvarNoArquivo();
    }

    private void SalvarNoArquivo()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_entidades, options);
            File.WriteAllText(_caminhoArquivo, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar {typeof(T).Name}: {ex.Message}");
        }
    }

    private List<T> CarregarDoArquivo()
    {
        if (!File.Exists(_caminhoArquivo)) return [];
        try
        {
            string jsonString = File.ReadAllText(_caminhoArquivo);
            if (string.IsNullOrWhiteSpace(jsonString))
                return [];
            var entidades = JsonSerializer.Deserialize<List<T>>
               (jsonString);
            return entidades ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar {typeof(T).Name}:{ex.Message}");
            return [];
        }
    }
}
