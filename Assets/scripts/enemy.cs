using System.Collections;
using System.Reflection;
using System.Threading;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float men = 1f;

    public float Speed = 3f;
    public float enhealth = 1;
    public GameObject worldtime;
    public float timey;
    public float pointer;
    public GameObject points;
    

    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 moveDirection;

    private void Awake()
    {
        worldtime = GameObject.FindGameObjectWithTag("timer");
        points = GameObject.FindGameObjectWithTag("pointer");
        pointer = points.GetComponent<points>().point;
        
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        timey = worldtime.GetComponent<worldtime>().timer;
        if (timey >= 12)
        {
            enhealth += timey/12;
        }
        if (timey >= 15)
        {
            Speed += timey/15;
        }
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
            pointer ++;
            Destroy(gameObject);
            
        }



         
    }
    //anv�nd worldtimer f�r att v�lja innan de spawnara vad deras health ska vara


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
