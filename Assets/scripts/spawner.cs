using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public GameObject enemyGameObject;
    public float spawnCooldown;
    public bool canspawn = true;
    

    public float minValue;
    public float maxValue;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //float ra2 = Random.Range(ra1, 10f);
        Vector3 pos1 = new Vector3(-4f, 0f, 0f);
        Vector3 pos2 = new Vector3(0f,-7f,0f);
        Vector3 pos3 = new Vector3(24f, 0f, 0f);
        Vector3 pos4 = new Vector3(0f, 7f, 0f);
        
        //float ra1 = Random.Range(pos1, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyGameObject != null && canspawn == true)
        {
            StartCoroutine(EnemySpawner());
            canspawn = false;
        }
 
    }
    private IEnumerator EnemySpawner()
    {
        yield return new WaitForSeconds(spawnCooldown);
        if (minValue == 0 && maxValue == 0)
        {
            Instantiate(enemyGameObject, transform.position, Quaternion.identity);
        }
        else
        {
            Vector2 randomLocation = new Vector2(Random.Range(minValue, maxValue), transform.position.y);
            Instantiate(enemyGameObject, randomLocation, Quaternion.identity);
        }
        canspawn = true;
    }

    private IEnumerator Ranposition()
    {
        while (true)
        {
            //Random.RandomRange(pos1,pos2,pos3,pos4);
        }
    }

}
