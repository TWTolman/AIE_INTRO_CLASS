using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;

public class HealthUI : MonoBehaviour {

    public Image HealthBar;
    public Slider myHealthBar;

    private ObjectHealth shipHealth;

    private void Awake()
    {
        shipHealth = GetComponent<ObjectHealth>();
    }


    // Update is called once per frame
    void Update ()
    {
        if (shipHealth != null)
        {
            myHealthBar.value = shipHealth.CurrentHealth;
        }
        

       // if (HealthBar !=null)
       // {


           // HealthBar.fillAmount = ShipHealth.CurrentHealth / ShipHealth.MaxHealth; 
        //}

    }
}
