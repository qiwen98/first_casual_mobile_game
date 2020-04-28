using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    Vector3 new_position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        new_position = Camera.main.transform.position + new Vector3(0, -10, 0);

        gameObject.transform.position = new_position;
    }
}
