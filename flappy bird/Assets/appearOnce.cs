using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearOnce : MonoBehaviour
{
    public static bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        if (started)
        {
            
            this.GetComponent<SpriteRenderer>().enabled = false;

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!started && Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            started = true;
            this.GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
