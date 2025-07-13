using UnityEngine;
using UnityEngine.UI;

public class Movel : MonoBehaviour
{
    public string nomeMovel; // Ex: "sofa"
    public Sprite imagemLibras;  // Sinal em Libras
    public Sprite imagemDoObjeto; // Imagem do próprio móvel
    [HideInInspector] public bool foiRespondido = false;

    public void MostrarLibrasAoLado()
    {
        Debug.Log("Mostrando Libras para: " + nomeMovel);
        GameObject img = new GameObject("Libras_" + nomeMovel);
        SpriteRenderer sr = img.AddComponent<SpriteRenderer>();
        sr.sprite = imagemLibras;
        img.transform.position = transform.position + Vector3.right * 1.5f;
        sr.sortingLayerName = "Default"; // ou o layer usado para sprites visíveis
        sr.sortingOrder = 10; // valor alto para aparecer por cima
        img.transform.localScale = new Vector3(0.3f, 0.3f, 1f);

    }
    public void MostrarLibrasUI(Transform painelUI)
    {
        GameObject novaImagem = new GameObject("ImagemLibras", typeof(RectTransform));
        novaImagem.transform.SetParent(painelUI, false);

        Image img = novaImagem.AddComponent<Image>();
        img.sprite = imagemLibras;
        img.rectTransform.anchoredPosition = new Vector2(100, 0); // ajustar posição
    }
}

