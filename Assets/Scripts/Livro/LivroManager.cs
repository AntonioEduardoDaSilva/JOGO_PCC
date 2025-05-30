using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivroManager : MonoBehaviour
{
    public Transform containerLivro;
    public GameObject prefabItemLivro;

    private string jogadorAtualID = GerenciadorJogadores.instancia.jogadorAtual.nomeUsuario; // Substitua pelo ID real do jogador logado

    void Start()
    {
        AtualizarLivroUI();
    }

    public void AtualizarLivroUI()
    {
        foreach (Transform child in containerLivro)
        {
            Destroy(child.gameObject);
        }

        var itens = LivroData.instancia.ObterLivroDoJogador(jogadorAtualID);

        foreach (LivroItem item in itens)
        {
            GameObject novoCard = Instantiate(prefabItemLivro, containerLivro);
            ItemLivroUI ui = novoCard.GetComponent<ItemLivroUI>();
            ui.Configurar(item);
        }

        Debug.Log("Itens do jogador carregados: " + itens.Count);
    }

    public void voltarParaMenu()
    {
        SceneManager.LoadScene("TelaMenu");
    }
}
