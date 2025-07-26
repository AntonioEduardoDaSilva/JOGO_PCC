using UnityEngine;

public class InteracaoComMoveis : MonoBehaviour
{
    public PainelDesafio3 painelDesafio;
    public GameObject personagem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movel movel = collision.gameObject.GetComponent<Movel>();
        if (movel != null && !movel.foiRespondido)
        {
            Debug.Log("Colidiu com: " + movel.nomeMovel);
            
            painelDesafio.AbrirPainel(movel);
            painelDesafio.personagem.SetActive(false);
        }
    }
}
