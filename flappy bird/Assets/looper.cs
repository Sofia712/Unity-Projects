using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Sky"|| collision.tag == "Ground")
        {
            
            //Debug.Log("collided with: " + collision.name);
            float widthOfObj = collision.bounds.size.x;
            float changeInX = widthOfObj * 8;
            collision.transform.Translate(changeInX, 0, 0);
        }
        if (collision.tag == "pipe pair")
        {
            float n = Random.Range(0.35f, 1.1f);
            collision.transform.Translate(6, (float)n -collision.transform.position.y , 0);

        }
        
    }

}
