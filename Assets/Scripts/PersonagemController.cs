using UnityEngine;

public class PersonagemController : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private Vector2 direcaoTeclado;
    private Vector2 direcaoUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento pelo teclado
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direcaoTeclado = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        Vector2 direcaoFinal = (direcaoTeclado + direcaoUI).normalized;
        rb.MovePosition(rb.position + direcaoFinal * velocidade * Time.fixedDeltaTime);
    }
    // Métodos que os botões vão chamar:
    public void MoverCima()
    { 
        direcaoUI = Vector2.up;
    }
    public void MoverBaixo()
    {
        direcaoUI = Vector2.down;
    }
    public void MoverEsquerda() 
    {
        direcaoUI = Vector2.left;
    }
    public void MoverDireita()
    {
        direcaoUI = Vector2.right;
    }
    public void PararMovimento()
    {
        direcaoUI = Vector2.zero;
    }
}
