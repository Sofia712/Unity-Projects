using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos5 : MonoBehaviour
{
    private void Awake()
    {
        float n = Random.Range(0.35f, 1.1f);
        transform.Translate(0, (float)n - transform.position.y, 0);
        //Debug.Log(gameObject.name + ": "+ transform.position);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
