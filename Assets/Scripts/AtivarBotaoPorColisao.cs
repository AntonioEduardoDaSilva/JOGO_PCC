using UnityEngine;

public class AtivarBotaoPorColisao : MonoBehaviour
{
    public GameObject botaoUI;

    void Start()
    {
        if (botaoUI != null)
            botaoUI.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisão com: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Zona"))
        {
            if (botaoUI != null)
                botaoUI.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zona"))
        {
            if (botaoUI != null)
                botaoUI.SetActive(false);
        }
    }
}
