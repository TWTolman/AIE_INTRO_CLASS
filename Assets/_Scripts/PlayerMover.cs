using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    //TODO: Program Game

    public float Speed = 500; //veriablecharacter speed

    public float MaxMovementSpeed = 5;

    public float MaxSprintMultiplyer = 2;

    private Rigidbody RB; //unity physics component

    private Vector3 IPDirection; // Input irection wordspace

    private float DT;

    public bool Sprint;

	// Use this for initialization
	void Start () {

        RB = GetComponent<Rigidbody>();

    }

    void UpdateInput()
    {
        IPDirection.x = Input.GetAxisRaw("Horizontal");
        IPDirection.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Joystick1Button1)) Sprint = true;
        else Sprint = false;

        //if (Input.GetKey(KeyCode.Space)) Sprint = true;
        //else Sprint = false;
    }

    public Vector3 VectorClamp(Vector3 CurrentVector, float XMax, float YMax, float ZMax)
    {
        Vector3 VecClamp;

        VecClamp.x = Mathf.Clamp(CurrentVector.x, -XMax, XMax);
        VecClamp.y = Mathf.Clamp(CurrentVector.y, -YMax, YMax);
        VecClamp.z = Mathf.Clamp(CurrentVector.z, -ZMax, ZMax);

        return VecClamp;

    }

	
    //Move a rigid body in a direction by a sped * delta time
    public void DoMovement(Rigidbody rigidbody, Vector3 Input, float speed, float DeltaTime, float MaxSpeed)
    {
     
      
      //ridgidbody.velocity = new Vector3(Mathf.Clamp(rigidbody.velocity.x, -MaxSpeed, MaxSpeed), RB.velocity.y,
                                 // Mathf.Clamp(rigidbody.velocity.z, -MaxSpeed, MaxSpeed)); 

       if (Sprint == true)
        {
            RB.AddForce(Input * Speed * MaxSprintMultiplyer * DeltaTime);
            rigidbody.velocity = VectorClamp(rigidbody.velocity, MaxSpeed * MaxSprintMultiplyer, MaxSpeed * MaxSprintMultiplyer, MaxSpeed * MaxSprintMultiplyer);
        }

       else
        {
            RB.AddForce(Input * Speed * DeltaTime);
             rigidbody.velocity = VectorClamp(rigidbody.velocity, MaxSpeed, MaxSpeed, MaxSpeed);



        }
    }

    
    
    // Update is called once per frame
	void Update () {
        DT = Time.deltaTime;

        UpdateInput();
        DoMovement(RB, IPDirection, Speed, DT,MaxMovementSpeed);

    
    }
}
