using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletspeed;
    private Camera mainCamera;
    [SerializeField]
    private float maxspeed = 10.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.up * bulletspeed * Time.deltaTime);

    }

   
   
}
