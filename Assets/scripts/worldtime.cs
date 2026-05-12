using UnityEngine;
using System.Collections;

public class worldtime : MonoBehaviour
{
    float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Timers());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Timers()
    {
        while (true)
        {
            timer++;
            yield return new WaitForSeconds(1);
        }
    }
}
