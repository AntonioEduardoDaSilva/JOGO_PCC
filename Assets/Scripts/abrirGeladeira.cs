using UnityEngine;

public class AbrirGeladeira : MonoBehaviour
{
    public GameObject geladeiraAberta;
    public GameObject geladeiraFechada;
    public GameObject botaoabrir;
    public GameObject ovo;
    private bool isOpen;
    public string tagDoJogador = "personagem";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ovo != null)
            ovo.SetActive(false);
        if (geladeiraAberta != null)
            geladeiraAberta.SetActive(false);
        if (botaoabrir != null)
            botaoabrir.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagDoJogador))
        {
            if (botaoabrir != null)
                botaoabrir.SetActive(true);
        }
    }
    void mostrarOvo()
    {
        if (ovo != null && isOpen)
        {
            ovo.SetActive(true);
        }
        else
        {
            if (ovo != null)
            {
                ovo.SetActive(false);
            }
        }
    }
    void aberta()
    {
        isOpen = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagDoJogador))
        {
            if (botaoabrir != null)
                botaoabrir.SetActive(false);
        }
    }
    public void abrirGeladeira()
    {
        geladeiraFechada.SetActive(false);
        geladeiraAberta.SetActive(true);
        aberta();
        mostrarOvo();
    }
}
