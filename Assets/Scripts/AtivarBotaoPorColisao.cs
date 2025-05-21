using UnityEngine;

public class AtivarBotaoPorColisao : MonoBehaviour
{
    public GameObject botaoUI;
    public string tagDoJogador = "personagem";

    void Start()
    {
        if (botaoUI != null)
            botaoUI.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagDoJogador))
        {
            if (botaoUI != null)
                botaoUI.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagDoJogador))
        {
            if (botaoUI != null)
                botaoUI.SetActive(false);
        }
    }
}

