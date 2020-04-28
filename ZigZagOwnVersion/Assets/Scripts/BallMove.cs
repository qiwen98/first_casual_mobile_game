using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    private Rigidbody rb;
    public bool started;
    public static bool gameover;
    [SerializeField]
    public GameObject particle;
    private float ForcetoUpward = 7;
    [SerializeField]
    private float speed = 8;
    private float gravity=-9.81f;
    public bool isGrounded = false;
    private bool isjumping = false;
    [SerializeField]
    private bool healthdecreased =false;
    private float transisionrate = 1f; //rate for swtiching path
    public static BallMove instance;
    private GameObject Recoverable_gameobject;
    float index;
    AudioClip moveClip;
    AudioClip RecoverClip;
    AudioClip Startsound;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        started = false;
        instance = this;
        index = 0;
        moveClip = Resources.Load<AudioClip>("jump_15");
        RecoverClip = Resources.Load<AudioClip>("game_over_22");
       Startsound = Resources.Load<AudioClip>("power_up_25");

    }

    


    void Update()
    {
       // CheckIsGrounded();

        if ((Input.GetMouseButtonDown(0) && started))
        {
            //switchDirection();
            SoundManager.instance.playsound(moveClip);
            switchtoLeftPath();

        }

        if(Input.GetMouseButtonDown(1) && started)
        {
            //switchDirection();
            SoundManager.instance.playsound(moveClip);
            switchtoRightPath();

        }

        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
               // Debug.Log("start");
                started = true;
                healthdecreased = false;
                SoundManager.instance.playsound(Startsound);

                GameManager.instance.Gamestart();

               

                    rb.velocity = new Vector3(0, 0, speed);
                
                  
             

            }
        }
    

      

        if (!Physics.Raycast(transform.position, Vector3.down, 20f))
        {

            rb.velocity = new Vector3(0, rb.mass * gravity, 0);
            //mass* gravity

            //decrease health
            

            if (ScoreManager.instance.Health <= 1&&!healthdecreased)
            {
               
                gameover = true;
                
                GameManager.instance.Gameover();
            }
            else
            {
                

                recoverState();
               
            }
           
           

        }


         

        
      /*  if (Input.GetKeyDown(KeyCode.Space))
        {

           
               //  rb.AddForce(new Vector3(0, ForcetoUpward, 0),ForceMode.VelocityChange);
                 // rb.velocity = rb.velocity + Vector3.up * 5;
                 // rb.AddForce(Vector3.forward);


              //  rb.velocity += new Vector3(0, ForcetoUpward, speed);
                isjumping = false;
                transform.Translate(new Vector3(0, 1, 0));

              //  Debug.Log("jump");

            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 0, speed);
        }

        */

    }

    private void recoverState()
    {


        if (!healthdecreased)
        {
            ScoreManager.instance.DecreaseHealth();
            healthdecreased = true;
            
            
        }

        rb.useGravity = false;
        //gobacktolast recoverable pos 
         index = GameObject.Find("terrains").transform.childCount/2-20;
        Recoverable_gameobject = GameObject.Find("terrains").transform.GetChild((int)index).gameObject;

        transform.position = Recoverable_gameobject.transform.position;

        //tell game manager to recover after 1s

        GameManager.instance.Gamerecover();

       
        //started is false now
        started = false;
        if(!started)
        {
           
                SoundManager.instance.playsound(RecoverClip);
              
        }
    }

   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            /* GameObject par=Instantiate(particle, col.gameObject.transform.position,Quaternion.identity);
             Destroy(col.gameObject, 0f);
             Destroy(par, 2f);*/
            ScoreManager.instance.incrementScore();
        }

        if (col.gameObject.tag == "Health")
        {
            
            ScoreManager.instance.incrementHealth();
        }

        if (col.gameObject.tag == "Bomb")
        {
            if (ScoreManager.instance.Health > 1)
            {
                recoverState();
            }
            else
            {

               GameManager.instance.Gameover();
                gameover = true;
                

            }


        }

    }

    void OnTriggerExit(Collider col)
    {
       
    }


    

    
    private void switchtoLeftPath()
    {
        
        
        
        Vector3 targetpos = this.transform.position + new Vector3(-2, 0, 0);
        
        rb.MovePosition(targetpos);
        

        //Debug.Log(rb.velocity.y);
    }

    private void switchtoRightPath()
    {

        Vector3 targetpos = this.transform.position + new Vector3(2, 0, 0);

        rb.MovePosition(targetpos );

       // Debug.Log("swtivh right");
    }


}