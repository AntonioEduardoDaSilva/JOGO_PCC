using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivroManager : MonoBehaviour
{
    public Transform containerLivro;        // Referência ao GridLayout
    public GameObject prefabItemLivro;      // Prefab visual para cada item

    void Start()
    {
        AtualizarLivroUI(); // Carrega os dados do singleton ao abrir a cena
        Debug.Log("Itens no livro: " + LivroData.instancia.itensAprendidos.Count);
    }

    public void AtualizarLivroUI()
    {
        // Limpa a UI atual
        foreach (Transform child in containerLivro)
        {
            Destroy(child.gameObject);
        }

        // Cria os itens a partir do singleton
        foreach (LivroItem item in LivroData.instancia.itensAprendidos)
        {
            GameObject novoCard = Instantiate(prefabItemLivro, containerLivro);
            ItemLivroUI ui = novoCard.GetComponent<ItemLivroUI>();
            ui.Configurar(item);
            Debug.Log("Novo item adicionado ao livro");
        }

    }
    public void voltarParaMenu()
    {
        SceneManager.LoadScene("TelaMenu");
    }
}
