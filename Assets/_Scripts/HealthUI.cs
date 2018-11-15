using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;

public class HealthUI : MonoBehaviour {


    public Slider myHealthBar;

    void Start()
    {
        ObjectHealth ShipHealth = GetComponent<ObjectHealth>();
        myHealthBar.value = ShipHealth.MaxHealth;

    }



    // Update is called once per frame
    void Update () {

        ObjectHealth ShipHealth = GetComponent<ObjectHealth>();
        myHealthBar.value = ShipHealth.CurrentHealth;

    }
}
