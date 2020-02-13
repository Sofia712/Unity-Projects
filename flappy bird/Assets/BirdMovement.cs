using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BirdMovement : MonoBehaviour
{
    public static int lives = 3;
    // Start is called before the first frame update
    Vector3 velocity = Vector3.zero;
    public Vector3 gravity = new Vector3(0, -9.8f, 0);
    Vector3 flapVel = new Vector3(0, 14f, 0);
    bool didFlap = false;
    public float maxSpeed = 2.3f;
    float forwardVelocity = 1f;
    Quaternion upRotation = Quaternion.Euler(0, 0, 35);
    Quaternion downRotation = Quaternion.Euler(0, 0, -90);
    float rotateSmooth = 2f;
    Quaternion look = Quaternion.Euler(0, 0, 0);
    Animator animator;
    [HideInInspector]public bool dead = false;
    float deathCoolDown = 1.5f;
    [HideInInspector] public static bool gameStart = false;
    public static bool gameOver;
    

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            deathCoolDown -= Time.deltaTime;
            
                if (deathCoolDown <= 0)
                {
                if (gameOver)
                    SceneManager.LoadScene(1);
                else
                    SceneManager.LoadScene(0);
                }
            
        }else
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
           
            if (gameStart == false)
            {
                gameStart = true;
                
            }
            didFlap = true;
                transform.rotation = upRotation;
                animator.SetTrigger("doFlap");
            
        }
        

    }

    void FixedUpdate()
    {
        if (dead || !gameStart) {
            Debug.Log("dead: " + dead + ", gameStart: " + gameStart);
            return;

        }
        velocity.x = forwardVelocity;
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, rotateSmooth * Time.deltaTime);
        velocity += gravity * Time.deltaTime;
        
        if (didFlap)
        {
            didFlap = false;
            if (velocity.y < 0)
                velocity.y = 0;
            velocity += flapVel;
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;

        

            if (velocity.y < 0)
        {
            look.y = -90;


        }
        else
        {
            look.y = 0;
        }

        
        //transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime*6);

       
        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag== "Ground" || collision.tag == "pipes") {
            lives--;

            if (lives <= 0)
            {
                gameOver = true;
                Debug.Log("gameover");
            }
            dead = true;
            gameStart = false;
            animator.SetTrigger("byeByeBirdy");
            if (collision.tag == "pipes")
            {
                
                float p = GameObject.FindWithTag("Ground").transform.position.y + GameObject.FindWithTag("Ground").GetComponent<BoxCollider2D>().bounds.size.y/2;
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, p, transform.position.z), Time.deltaTime * 6);
            }
            
        }
    }
    

}
