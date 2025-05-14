using UnityEngine;

public class PersonagemController : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private Vector2 direcao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento contínuo com base na direção
        rb.linearVelocity = direcao * velocidade;
    }

    // Métodos que os botões vão chamar:
    public void MoverCima()    => direcao = Vector2.up;
    public void MoverBaixo()   => direcao = Vector2.down;
    public void MoverEsquerda()=> direcao = Vector2.left;
    public void MoverDireita() => direcao = Vector2.right;

    public void PararMovimento() => direcao = Vector2.zero;
}
