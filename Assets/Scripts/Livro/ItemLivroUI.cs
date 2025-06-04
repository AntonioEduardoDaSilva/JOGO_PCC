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

        imagemItem.rectTransform.sizeDelta = new Vector2(200, 200); // ou o valor que você quiser
        imagemSinal.rectTransform.sizeDelta = new Vector2(200, 200); // mesmo valor para padronizar
    }
}
