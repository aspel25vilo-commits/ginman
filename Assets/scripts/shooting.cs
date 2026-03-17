using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform canon;
    public GameObject Bulletprefab;
    public float bulletspeed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Bulletprefab, canon.position, canon.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(canon.up * bulletspeed, ForceMode2D.Impulse);

    }
}
