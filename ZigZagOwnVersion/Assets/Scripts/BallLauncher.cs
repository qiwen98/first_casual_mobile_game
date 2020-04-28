using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour
{

    public Rigidbody ball;
    [SerializeField]
    private Vector3 targetpos;

    public float h = 2 ;
    public float gravity = -18;

    public bool debugPath;
    AudioClip jumpClip;

    void Start()
    {
        //  ball.useGravity = false;
        targetpos =  new Vector3(0, 0, 0);

        //Load an AudioClip (Assets/Resources/Audio/audioClip01.mp3)
         jumpClip = Resources.Load<AudioClip>("jump_26");

    }

    void Update()
    {
        targetpos = transform.position + new Vector3(0, 0, 5);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.playsound(jumpClip);

            if ( BallMove.instance.started) {
                
                Launch();
            }
           
        }

       
    }

    void Launch()
    {
        Physics.gravity = Vector3.up * gravity;
        ball.useGravity = true;
        ball.velocity = CalculateLaunchData();
    }

    Vector3 CalculateLaunchData()
    {
    
       
        float displacementY = targetpos.y - ball.position.y;
        Vector3 displacementXZ = new Vector3(targetpos.x - ball.position.x, 0, targetpos.z - ball.position.z);
        float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / ( time/3);

        return  (velocityXZ + velocityY );
    }


    
}