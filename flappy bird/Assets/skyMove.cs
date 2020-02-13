using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyMove : MonoBehaviour
{
     public float speed = 0.99f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BirdMovement.gameStart && !GameObject.Find("Bird").GetComponent<BirdMovement>().dead)
            transform.Translate(speed * Time.deltaTime, 0, 0);
    }

}
