using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemLivroUI : MonoBehaviour
{
    public Image imagemItem;
    public TextMeshProUGUI textoPalavra;
    public Image imagemSinal;
    public TextMeshProUGUI textoComodo;

    public void Configurar(LivroItem item)
    {
        imagemItem.sprite = item.imagem;
        imagemSinal.sprite = item.sinalLibras;
        textoPalavra.text = item.palavraPortugues;
        textoComodo.text = "Missão: " + item.comodoAprendido;
    }
}
