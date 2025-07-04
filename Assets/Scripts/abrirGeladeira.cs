using UnityEngine;

public class AbrirGeladeira : MonoBehaviour
{
    public GameObject geladeiraAberta;
    public GameObject geladeiraFechada;
    public GameObject botaoabrir;
    public GameObject ovo;
    public GameObject queijo;
    public GameObject uva;
    private bool isOpen;
    public string tagDoJogador = "personagem";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ovo != null)
            ovo.SetActive(false);
        if (uva != null)
            uva.SetActive(false);
        if (queijo != null)
            queijo.SetActive(false);
        if (geladeiraAberta != null)
            geladeiraAberta.SetActive(false);
        if (botaoabrir != null)
            botaoabrir.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mostrarQueijo();
        mostrarOvo();
        mostrarUva();
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
        if (ovo != null && isOpen && GameManager.lancheEscolhido=="omelete")
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
    void mostrarUva()
    {
        if (uva != null && isOpen && GameManager.lancheEscolhido=="salada")
        {
            uva.SetActive(true);
        }
        else
        {
            if (uva != null)
            {
                uva.SetActive(false);
            }
        }
    }
    void mostrarQueijo()
    {
        if (queijo != null && isOpen && GameManager.lancheEscolhido=="pao")
        {
            queijo.SetActive(true);
        }
        else
        {
            if (queijo != null)
            {
                queijo.SetActive(false);
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
        mostrarQueijo();
        mostrarUva();
    }
}
