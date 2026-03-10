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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouse_pos = GetWorldPositionFromMouse();
        var p = transform.position;
     
        Vector2 dv = mouse_pos - new Vector2(p.x, p.y);
      
        float rot = Mathf.Atan2(dv.y, dv.x);
        // float rot = dv.Rotation();
        //transform.rotation = Rad2Qat(rot)
        //transform.rotation = rot / 2 * Mathf.PI;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }
            



        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {

            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {

            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {

            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
           
            moveX = 1f;

        }
        Vector3 move = new Vector3(moveX, moveY, 0f).normalized;
        transform.Translate(move * playerspeed * Time.deltaTime);
    }

    void SpawnProjectile()
    {
        Vector3 spawnPosition = transform.position + (transform.forward * spawnOffset);

        GameObject newObject = Instantiate(projectilePrefab, spawnPosition, transform.rotation);
    }
    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
