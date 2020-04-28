using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ball;
    private Vector3 offset;
    private Vector3 zoomVector;
    private bool zoomstarted = false;
    float lerprate = 1f;
    public static CameraFollow instance;
    // Start is called before the first frame update
    void Start()
    {
       
        ball = GameObject.FindWithTag("Player");

        if (ball != null)
        {
            Debug.Log("ball found");
        }
        instance = this;
        offset = ball.transform.position-transform.position;
        zoomVector =new Vector3(0,0,6);
        // Debug.Log(BallMove.gameover);
        Invoke("cameraZoom",1f);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!BallMove.gameover&&zoomstarted)
        {
            following();
        }
    }

    public void cameraZoom()
    {
        Vector3 currentpos = transform.position;
        Vector3 targetpos = ball.transform.position - offset + zoomVector;
        currentpos = Vector3.Lerp(currentpos, targetpos, 0.5f * Time.deltaTime);
       
        transform.position = currentpos;
       
        zoomstarted = true;
    }

    void following()
    {

        Vector3 currentpos = transform.position;
        Vector3 targetpos = ball.transform.position - offset + zoomVector;
        currentpos = Vector3.Lerp(currentpos, targetpos, lerprate* Time.deltaTime);
        transform.position = currentpos;

    }
}
