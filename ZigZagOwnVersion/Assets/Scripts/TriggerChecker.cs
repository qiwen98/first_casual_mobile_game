using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{

    int new_index=0;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.z < Camera.main.transform.position.z)
        {
            fallingdown();
        }

        
    }

     void OnTriggerExit(Collider col)
    {
       if(col.gameObject.tag=="Player")
        {
           // Debug.Log("fall");
            Invoke("fallingdown", 1f);

            float random = Random.Range(0, 9);

            if(random>6)
            {
                Invoke("SiblingstoFalldown", 1f);
            }
                

        }
      
       
    }

    void fallingdown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;


        Destroy(this.transform.parent.gameObject, 2f);
      
    }

    public void SiblingstoFalldown()
    {
        //Debug.Log(transform.GetSiblingIndex());
        new_index = Random.Range(50, 65);
        GameObject ToBeFall_platform = transform.parent.parent.GetChild(new_index).gameObject;
        MeshRenderer meshrender = ToBeFall_platform.GetComponent<MeshRenderer>();

        meshrender.material.SetColor("_Color", Color.red);

        if (ToBeFall_platform .transform.position.z> Camera.main.transform.position.z)
            if(ToBeFall_platform!=null)
            {
                ToBeFall_platform.GetComponentInChildren<TriggerChecker>().fallingdown();
            }
           
        
        
    }


}
