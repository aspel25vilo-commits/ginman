using System.Collections;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float healthtimer = 1f;
    public float men = 1f;
    public float Speedtimer = 1f;
    public float Speed = 3f;
    public float enhealth = 1;
    private worldtime worldtime;

    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 moveDirection;

    private void Awake()
    {
        StartCoroutine(upgrade());
        StartCoroutine(upgradespeed());
        worldtime = GetComponent<worldtime>();
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
    //använd worldtimer för att välja innan de spawnara vad deras health ska vara
    private IEnumerator upgrade()
    {
        while (true)
        {
            yield return new WaitForSeconds(healthtimer);
            enhealth++;
                    
        }
    }
    private IEnumerator upgradespeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(Speedtimer);
            
            Speed++;
            
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
