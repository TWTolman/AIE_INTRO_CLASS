using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyOnLeave : MonoBehaviour {

    public float EnemyDeathVelocity;

   void OnTriggerEnter(Collider other)
        
    {

       
        if (other.gameObject.tag == "Enemy")
        {
            //GetComponent<Rigidbody>().AddForce(transform.forward * -EnemyDeathVelocity * 5);
            Destroy(other.gameObject, 0.3f);
           
        }

         
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
