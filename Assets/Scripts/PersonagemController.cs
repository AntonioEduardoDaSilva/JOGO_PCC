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

        // Atualiza animações
        animator.SetFloat("Horizontal", direcaoFinal.x);
        animator.SetFloat("Vertical", direcaoFinal.y);
        animator.SetBool("IsMoving", direcaoFinal.magnitude > 0.1f);

        // FlipX para reutilizar a animação direita para esquerda
        if (direcaoFinal.x < -0.1f)
            spriteRenderer.flipX = true;
        else if (direcaoFinal.x > 0.1f)
            spriteRenderer.flipX = false;
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
