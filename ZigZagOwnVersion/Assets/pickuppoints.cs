using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickuppoints : MonoBehaviour
{
    public GameObject particle;
    public AudioClip collidesound;

    // Start is called before the first frame update
    void Start()
    {

       
        // Invoke("destroyown", 25f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);

        if (this.gameObject.transform.position.z < Camera.main.transform.position.z)
        {
            destroyown();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            SoundManager.instance.playsound(collidesound);
            GameObject par = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity);
           
            Destroy(par, 1f);
            Destroy(this.gameObject, 0f);
        }
    }

    void destroyown()
    {
        Destroy(this.gameObject, 0f);
    }

}
