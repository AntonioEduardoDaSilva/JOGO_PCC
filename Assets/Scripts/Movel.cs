using UnityEngine;

public class Movel : MonoBehaviour
{
    public string nomeMovel; // Ex: "sofa"
    public Sprite imagemLibras;  // Sinal em Libras
    public Sprite imagemDoObjeto; // Imagem do próprio móvel
    [HideInInspector] public bool foiRespondido = false;

    public void MostrarLibrasAoLado()
    {
        GameObject img = new GameObject("Libras_" + nomeMovel);
        SpriteRenderer sr = img.AddComponent<SpriteRenderer>();
        sr.sprite = imagemLibras;
        img.transform.position = transform.position + Vector3.right * 1.5f;
    }
}

