using UnityEngine;

public class AbrirGeladeira : MonoBehaviour
{
    public GameObject geladeiraAberta;
    public GameObject geladeiraFechada;
    public GameObject botaoabrir;
    public GameObject ovo;
    public string tagDoJogador = "personagem";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ovo.SetActive(false);
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
        ovo.SetActive(true);
    }
}
