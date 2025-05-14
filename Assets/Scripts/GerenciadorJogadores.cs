using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GerenciadorJogadores : MonoBehaviour
{
    public static GerenciadorJogadores instancia;

    [Header("Lista de jogadores cadastrados")]
    public List<Jogador> jogadores = new List<Jogador>();

    [Header("Jogador logado atualmente")]
    public Jogador jogadorAtual;

    void Awake()
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

    // Verifica se um nome de usuário já foi cadastrado
    public bool UsuarioExiste(string usuario)
    {
        return jogadores.Any(j => j.nomeUsuario == usuario);
    }

    // Retorna o jogador correspondente ao nome de usuário
    public Jogador ObterJogador(string usuario)
    {
        return jogadores.FirstOrDefault(j => j.nomeUsuario == usuario);
    }

    // Adiciona novo jogador se ainda não existir
    public bool AdicionarJogador(Jogador j)
    {
        if (UsuarioExiste(j.nomeUsuario))
        {
            Debug.LogWarning("Usuário já cadastrado: " + j.nomeUsuario);
            return false;
        }

        jogadores.Add(j);
        Debug.Log("Novo jogador adicionado: " + j.nomeUsuario);
        return true;
    }
}
