using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float velocidade = 5.0f;
    public float impulso = 800.0f;
    public float gravidade = 2.0f;

    public Transform sensorChao;
    private bool estaNoChao;
    private bool pular;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        rb.gravityScale = gravidade;
    }
    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal");

        float px = movimento * velocidade * Time.deltaTime;
        transform.Translate(px, 0.0f, 0.0f);

        if (movimento > 0)
        {
            sr.flipX = false;
        }
        else if (movimento < 0)
        {
            sr.flipX = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            pular = true;
        }

        estaNoChao = Physics2D.Linecast(transform.position, sensorChao.position, 1 << LayerMask.NameToLayer("Ground"));

        anim.SetBool("IsRunning", movimento != 0);
        anim.SetBool("IsJumping", !estaNoChao);
    }

    private void FixedUpdate()
    {
        if (pular && estaNoChao)
        {
            rb.AddForce(Vector2.up * impulso);
            pular = false;
        }
    }

    void OnColliderEnter2D()
    {

    }
}