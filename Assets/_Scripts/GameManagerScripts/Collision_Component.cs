using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Component : MonoBehaviour {

    public Attack_Component Attack;
    public ObjectHealth Health;



    void OnCollisionEnter(Collision other)
    {
        ObjectHealth Health = other.gameObject.GetComponent<ObjectHealth>();

        if (Health != null)

        {
          Attack_Component MyAttack = GetComponent<Attack_Component>();
            //MyAttack.DoDamage(Health.TakeDamage);

        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
