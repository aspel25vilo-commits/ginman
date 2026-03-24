using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
    public float Speed = 100;
    Vector2 move = new Vector2(1f, 1f);
    public GameObject player;
    public float enhealth = 1;
    Rigidbody2D rb;
    public float attackdelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Attackcoldown());
    }

    private void Awake()
    {

        player = GameObject.Find("player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
   
        move = player.transform.position - transform.position;
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




            return null;
            

        }

    }
    private void Entakedamage()
    {
        enhealth--;

    }
}
