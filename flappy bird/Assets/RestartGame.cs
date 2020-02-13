using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            BirdMovement.lives = 3;
            BirdMovement.gameStart = false;
            BirdMovement.gameOver = false;
            appearOnce.started = false;
            SceneManager.LoadScene(0);
        }
    }
}
