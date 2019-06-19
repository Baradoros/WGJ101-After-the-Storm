using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBarCleanliness : MonoBehaviour
{
    public int clutterCount;
    public int drunkCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collide)
    {
        if(collide.gameObject.tag == ("Clutter"))
        {
            clutterCount++;
        }
        if (collide.gameObject.tag == ("Drunk"))
        {
            drunkCount++;
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == ("Clutter"))
        {
            clutterCount--;
        }
        if (collide.gameObject.tag == ("Drunk"))
        {
            drunkCount--;
        }
    }
}
