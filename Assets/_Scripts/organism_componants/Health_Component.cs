using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Component : MonoBehaviour {

    public float MaxHealth = 100.0f;
    public float CurrentHealth;
    public bool canRegenHealth  = false ;
    public float HealthRegenSpeed = 2.0f;

    float DT;

    public float MaxRegenDelay = 5.0f;
    private float RegenDelayCountdown;




    // Use this for initialization

   
    public void TakeDamage(float DamageAmount)  
    {
        CurrentHealth -= DamageAmount;
        RegenDelayCountdown = MaxRegenDelay;

        if (CurrentHealth <= 0)
            Destroy(gameObject);




    }





    void Start () {

        CurrentHealth = MaxHealth;
        DT = Time.deltaTime;


       
	}
	
	// Update is called once per frame
	void Update () {



        DT = Time.deltaTime;
        ManageHealthRegen();

        
		
	}

    public void Heal (float Amount)

    {
       CurrentHealth += Amount; 


    }

    public void ManageHealthRegen()
    {
        if (CurrentHealth < MaxHealth && canRegenHealth == true && RegenDelayCountdown <= 0)

        {
            Heal(DT * HealthRegenSpeed);
            

        }

    }
}
