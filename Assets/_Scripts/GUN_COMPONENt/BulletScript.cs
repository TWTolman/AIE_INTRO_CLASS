using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    //public LayerMask layer;

    public GameObject Owner;
    public float DamageValue = 2.0f;

    public void OnTriggerEnter(Collider other)
    {
     if (other.gameObject != Owner)
        {

            Health_Component TempHealthComponentReference = other.GetComponent<Health_Component>();
               

            if (TempHealthComponentReference != null)
            {
                TempHealthComponentReference.TakeDamage(DamageValue);
            }
            

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
