using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPhysics : MonoBehaviour {

    Collider MyCollider;

 

   void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag == "TopWall")
        {
            MyCollider = GetComponent<Collider>();
            MyCollider.isTrigger = false;
            Debug.Log("Trigger exit");
        }

    }

    //void OnTriggerExit (Collider other)

    //{


    //}



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
