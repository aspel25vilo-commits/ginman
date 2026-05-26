using UnityEngine;

public class level : MonoBehaviour
{
    public int point = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addpoints(int points)
    {
        point += points;
    }

        //if point 10 randomrange attack, attackspeed, health, special(maybe explosion)
    }
