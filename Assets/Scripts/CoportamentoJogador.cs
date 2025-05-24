using UnityEngine;

public class ComportamentoJogador : MonoBehaviour
{
    public Jogador jogador;

    public void Inicializar(Jogador jogadorReferenciado)
    {
        jogador = jogadorReferenciado;
    }

    public void VerificarSeMorreu()
    {
        if (!jogador.EstaVivo())
        {
            Debug.Log("Jogador morreu. Destruindo personagem.");
            Destroy(gameObject);
        }
    }
}