using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    //public LayerMask layer;

    public GameObject Owner;

    public void OnTriggerEnter(Collider other)
    {
     if (other.gameObject != Owner)
            {
            Destroy(gameObject);
            }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       

        
		
	}
}
