using UnityEngine;
using UnityEngine.UIElements;


public class gunman : MonoBehaviour
{
    
    public float playerspeed = 1f;
    public Vector3 spawnPosition;
    public GameObject projectilePrefab;
    public GameObject mouse;
    public float spawnOffset = 1.0f;
    private Camera mainCamera;
    public Rigidbody2D rb;
    Vector2 movementpos;
    Vector2 mousepos;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {


        movementpos.x = Input.GetAxisRaw("Horizontal");
        movementpos.y = Input.GetAxisRaw("Vertical");
        Debug.Log($"movement {movementpos.x} {movementpos.y}");

        mousepos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        movementpos.Normalize();


    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementpos * playerspeed * Time.fixedDeltaTime);
        

        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
           
    }



    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
