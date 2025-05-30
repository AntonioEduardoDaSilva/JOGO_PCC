using System.Collections.Generic;
using UnityEngine;

public class LivroData : MonoBehaviour
{
    public static LivroData instancia;

    // Dicionário que associa um ID de jogador com seus itens aprendidos
    public Dictionary<string, List<LivroItem>> livrosPorJogador = new Dictionary<string, List<LivroItem>>();

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Cria um novo livro para o jogador
    public void CriarLivroParaJogador(string jogadorID)
    {
        if (!livrosPorJogador.ContainsKey(jogadorID))
        {
            livrosPorJogador[jogadorID] = new List<LivroItem>();
            Debug.Log("Livro criado para jogador: " + jogadorID);
        }
    }

    // Adiciona item ao livro do jogador
    public void AdicionarItemAoLivro(string jogadorID, LivroItem item)
    {
        if (!livrosPorJogador.ContainsKey(jogadorID))
        {
            CriarLivroParaJogador(jogadorID);
        }
        livrosPorJogador[jogadorID].Add(item);
    }

    // Recupera o livro do jogador atual
    public List<LivroItem> ObterLivroDoJogador(string jogadorID)
    {
        if (!livrosPorJogador.ContainsKey(jogadorID))
        {
            CriarLivroParaJogador(jogadorID);
        }
        return livrosPorJogador[jogadorID];
    }
}
