using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    Text text;
    static int sc = 0;
    static int hsc = 0;

    static public void AddPoint()
    {
        sc++;
        if (sc > hsc)
        {
            hsc = sc;
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    void Start()
    {
        if (BirdMovement.lives == 3)
        {
            sc = 0;
        }
        hsc = PlayerPrefs.GetInt("highscore", 0);
        
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", hsc);
    }
    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + sc +"\nHigh Score : "+hsc;
    }
}
