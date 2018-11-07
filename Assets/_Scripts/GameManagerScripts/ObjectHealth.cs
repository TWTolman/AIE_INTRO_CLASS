using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{



    public float MaxHealth = 100.0f;
    public float CurrentHealth;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;

    }



    public void TakeDamage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;


        if (CurrentHealth <= 0)
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {


    }
}
