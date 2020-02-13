using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracksBird : MonoBehaviour
{

    Transform birdTransform;
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(player == null)
        {
            Debug.LogError("Couldn't find player.");
            return;
        }
        birdTransform = player.transform;
        offsetX = transform.position.x - birdTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (birdTransform != null)
        {
            
            transform.position = new Vector3(birdTransform.position.x + offsetX, transform.position.y, transform.position.z);
        }
    }
}
