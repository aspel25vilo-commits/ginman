using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
    public float Speed = 1f;
    Vector2 move = new Vector2(1f, 1f);
    public GameObject player;
    public float enhealth = 1;
    Rigidbody2D rb;
    public float attackdelay = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Attackcoldown());
    }

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
   
        move = player.transform.position - transform.position;
        Debug.Log($"Move v {move}");
        if (enhealth < 1)
        {
            
            Destroy(this.gameObject);
        }
    }
    private IEnumerator Attackcoldown()
    {
        while (true)
        {

            rb.AddForce(move.normalized * Speed);
            Debug.Log($"{this.gameObject} move: {move}");
           


            yield return new WaitForSeconds(attackdelay);


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Entakedamage();
        }
    }
    private void Entakedamage()
    {
        enhealth--;

    }
}
