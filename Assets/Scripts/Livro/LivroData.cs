using System.Collections.Generic;
using UnityEngine;

public class LivroData : MonoBehaviour
{
    public static LivroData instancia;
    public List<LivroItem> itensAprendidos;
    void Start()
    {
        LivroItem itemTeste = new LivroItem
        {
            palavraPortugues = "Avião",
            imagem = Resources.Load<Sprite>("Componentes tela nivel 1/aviao"),
            sinalLibras = Resources.Load<Sprite>("Componentes tela nivel 1/sinalAviao"),
            comodoAprendido = "Quarto"
        };
        LivroItem itemTeste1 = new LivroItem
        {
            palavraPortugues = "Espelho",
            imagem = Resources.Load<Sprite>("Componentes tela nivel 1/aviao"),
            sinalLibras = Resources.Load<Sprite>("Componentes tela nivel 1/sinalAviao"),
            comodoAprendido = "Quarto"
        };
        LivroItem itemTeste2 = new LivroItem
        {
            palavraPortugues = "oculos",
            imagem = Resources.Load<Sprite>("Componentes tela nivel 1/aviao"),
            sinalLibras = Resources.Load<Sprite>("Componentes tela nivel 1/sinalAviao"),
            comodoAprendido = "Quarto"
        };

        // Adiciona ao singleton
        LivroData.instancia.itensAprendidos.Add(itemTeste);
        LivroData.instancia.itensAprendidos.Add(itemTeste1);
        LivroData.instancia.itensAprendidos.Add(itemTeste2);
        LivroData.instancia.itensAprendidos.Add(itemTeste2);
        LivroData.instancia.itensAprendidos.Add(itemTeste2);
        LivroData.instancia.itensAprendidos.Add(itemTeste2);
        
        Debug.Log("Item adicionado: " + itemTeste.palavraPortugues);
        Debug.Log("Imagem carregada: " + (itemTeste.imagem != null));
        Debug.Log("Sinal carregado: " + (itemTeste.sinalLibras != null));

    }


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
}
