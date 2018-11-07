using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    public float EnemyLaunchVelocity;



    // Use this for initialization
    void Start () {
        EnemyLaunchVelocity = EnemyLaunchVelocity *  Random.Range(25,50);
     GetComponent<Rigidbody>().AddForce(transform.forward * - EnemyLaunchVelocity);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
