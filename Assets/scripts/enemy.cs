using UnityEngine;

public class enemy : MonoBehaviour
{
    public float Speed = 3f;
    public float enhealth = 1;

    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 moveDirection;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            moveDirection = ((Vector2)player.transform.position - rb.position).normalized;
        }

        if (enhealth < 1)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        rb.MovePosition(rb.position + moveDirection * Speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            TakeDamage();
        }
    }

    /// <summary>Reduces enemy health by one hit.</summary>
    private void TakeDamage()
    {
        enhealth--;
    }
}
