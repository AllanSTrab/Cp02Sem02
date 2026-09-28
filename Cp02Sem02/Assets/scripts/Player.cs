using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);

        if (movimento > 0)
        {
            sprite.flipX = false; 
        }
        else if (movimento < 0)
        {
            sprite.flipX = true; 
        }
    }
}
