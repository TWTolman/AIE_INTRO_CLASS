using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    



    // Use this for initialization
  


    public void  EnemyLaunch (Vector3 Direction)
        {
        
        GetComponent<Rigidbody>().AddForce(Direction, ForceMode.VelocityChange);



    }

        
        // Update is called once per frame
	void Update () {
		
	}
}
