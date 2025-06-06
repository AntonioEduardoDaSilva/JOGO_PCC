using UnityEngine;

public class PersonagemController : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 direcaoTeclado;
    private Vector2 direcaoUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimento pelo teclado
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        direcaoTeclado = new Vector2(Horizontal, Vertical).normalized;

        // Determina direção final (teclado + UI)
        Vector2 direcaoFinal = (direcaoTeclado + direcaoUI).normalized;

        // Animação baseada apenas na direção final
        if (direcaoFinal.y > 0)
        {
            animator.Play("Move_up");
        }
        else if (direcaoFinal.y < 0)
        {
            animator.Play("Move_down");
        }
        else if (direcaoFinal.x > 0)
        {
            animator.Play("Move_right");
        }
        else if (direcaoFinal.x < 0)
        {
            animator.Play("Move_left");
        }
        else if (direcaoFinal.x == 0 && direcaoFinal.y == 0)
        {
            animator.Play("Idle");
        }
    }


    void FixedUpdate()
    {
        Vector2 direcaoFinal = (direcaoTeclado + direcaoUI).normalized;
        rb.MovePosition(rb.position + direcaoFinal * velocidade * Time.fixedDeltaTime);
    }

    // Métodos chamados pelos botões UI
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
