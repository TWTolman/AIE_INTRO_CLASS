using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public bool IsGrounded;

    public float Hitdistance;

    public LayerMask layer;







    void Start()
    {
       
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 2000);
        }

        if (IsGrounded)
            Hitdistance = 0.35f;
        else
            Hitdistance = 0.15f;

        if (Physics.Raycast(transform.position - new Vector3(0, 0.35f, 0), transform.up, Hitdistance, layer))
            IsGrounded = true;
        else
            IsGrounded = false;

        

       
    }

}





     
