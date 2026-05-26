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
    public GameObject damge;
    public float damger;
    public float realdamge;



    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 moveDirection;
    public GameObject Level;

    private void Awake()
    {
        worldtime = GameObject.FindGameObjectWithTag("timer");
        Level = GameObject.FindGameObjectWithTag("pointer");
        damge = GameObject.FindGameObjectWithTag("tank");
        

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

        damger = damge.GetComponent<gunman>().damage;
        
        if (player != null)
        {
            
            moveDirection = ((Vector2)player.transform.position - rb.position).normalized;
        }

        if (enhealth < 1)
        {
            
            Level.GetComponent<level>().addpoints(1);
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
        realdamge = enhealth - damger;
    }
}
