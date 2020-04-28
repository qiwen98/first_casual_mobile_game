using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public Transform instantiateParent;
    public Transform SpawnObjects;
    public GameObject platform;
    public GameObject diamond;
    public GameObject HealthPickup;
    public GameObject Bomb;

    public static PlatformSpawner instance;
    [SerializeField]
    Vector3 lastposition;
    float size;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        lastposition = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i=0;i<20;i++)
        { spawnPlatform(); }
      
    }

    public void startspawning()
    {
        InvokeRepeating("spawnPlatform", 1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameover==true)
        {
            stopspawning();
        }
    }

    public void stopspawning()
    {
        CancelInvoke("spawnPlatform");
    }


    void spawnY()
    {
        Vector3 pos = lastposition;
        Vector3 pos_x1 = lastposition;
        Vector3 pos_x2 = lastposition;

        float rand3 = Random.Range(0, 3);

        
            pos.y += rand3;
            pos.z += size;
            pos_x1.x -= size;
            pos_x2.x += size;




        if (platform != null)
        {
           
     
           GameObject middleplat= (GameObject)Instantiate(platform, pos, Quaternion.identity, instantiateParent);
            GameObject leftplat= (GameObject)Instantiate(platform, pos_x1, Quaternion.identity, instantiateParent);
            GameObject rightplat = (GameObject)Instantiate(platform, pos_x2, Quaternion.identity, instantiateParent);



            /*TriggerChecker leftplatScript = leftplat.GetComponentInChildren<TriggerChecker>();
            leftplatScript.SignaltoFalldown();
            if (rand3 == 0)
            {
                leftplat.GetComponentInChildren<TriggerChecker>().SignaltoFalldown();
            }

            if (rand3==1)
            {
                middleplat.GetComponentInChildren<TriggerChecker>().SignaltoFalldown();
            }

            if (rand3 == 2)
            {
                rightplat.GetComponentInChildren<TriggerChecker>().SignaltoFalldown();
            }
            */

        }


        lastposition = pos;


        spawnDiamond(new Vector3(pos.x, pos.y + 1, pos.z));
        spawnDiamond(new Vector3(pos.x-size, pos.y + 1, pos.z));
        spawnDiamond(new Vector3(pos.x+size, pos.y + 1, pos.z));

        
        spawnBomb(new Vector3(pos.x, pos.y , pos.z));


    }

    void spawnZ()
    {
        Vector3 pos = lastposition;
        Vector3 pos_x1=lastposition; 
        Vector3 pos_x2=lastposition;
        pos.z += size;

        pos_x1.x -=size;
        pos_x2.x +=size;



        // pos.x += 1 * size;

        if (platform != null)
            {
                Instantiate(platform, pos, Quaternion.identity, instantiateParent);
                Instantiate(platform, pos_x1, Quaternion.identity, instantiateParent);
                Instantiate(platform, pos_x2, Quaternion.identity, instantiateParent);
        }
            lastposition = pos;

            spawnDiamond(new Vector3(pos.x, pos.y + 1, pos.z));
             spawnHealth(new Vector3(pos.x, pos.y + 3, pos.z));



    }

    void spawnDiamond(Vector3 location)
    {
        float rand2 = Random.Range(0, 9);
        if(rand2<4)
        Instantiate(diamond, location, diamond.transform.rotation, SpawnObjects);
        
    }

    void spawnHealth(Vector3 location)
    {
        float rand2 = Random.Range(0, 100);
        float random_x = Random.Range(-1, 2);

        location.x += (random_x*2);
        if (rand2 < 5)
            Instantiate(HealthPickup, location, HealthPickup.transform.rotation, SpawnObjects);

    }

    void spawnBomb(Vector3 location)
    {
        float rand2 = Random.Range(0, 100);
        float random_y= Random.Range(2, 5);
        float random_x = Random.Range(-1, 2);

        location.x += (random_x * 2);
        location.y += random_y;

        if (rand2 < 8)
            Instantiate(Bomb, location, Bomb.transform.rotation, SpawnObjects);

    }

    void spawnPlatform()
    {
        if (BallMove.gameover)
        {
            return;
        }

        float rand = Random.Range(0, 9);


        if (rand > 3)
        {
            spawnZ();
        }
        spawnY();

    }
}
