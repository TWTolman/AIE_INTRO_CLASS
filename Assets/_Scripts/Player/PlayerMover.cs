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

    public Camera MainCamera;




    public RaycastHit RaycastFromScreenPoint(Vector2 ScreenPoint, Camera cam)
        {


        RaycastHit Result;

        Ray ray = cam.ScreenPointToRay(ScreenPoint);

        

        Physics.Raycast ( ray, out Result, 1000.0f);

        return Result;


        }


    //public void DoRightStickLook ()
   // {

        

   // }


    //public void DoMouseLook (Vector2 MousePosition)
    //{

    //    if (MainCamera != null)
    //    { 

    //    RaycastHit hit = RaycastFromScreenPoint(MousePosition, MainCamera);


    //        //Vector3 Dir = (hit.point - transform.position).normalized;
    //    Vector3 Dir = (transform.position - hit.point).normalized * -1;

            
    //        Dir.y = 0;
    //        //Dir.z = 0;

    //        transform.forward = Dir;
    //    }


    //    else
    //    {
    //        Debug.Log("assing camera");

    //    }

      
    //}

  

// Use this for initialization
void Start () {

        RB = GetComponent<Rigidbody>();

    }



void UpdateInput()
    {
          
       


        IPDirection.x = Input.GetAxisRaw("Horizontal");
        IPDirection.z = Input.GetAxisRaw("Vertical");

        float H2 = Input.GetAxisRaw("Horizontal2");
        float V2 = Input.GetAxisRaw("Vertical2");

        Vector3 LookDirection = new Vector3(Input.GetAxisRaw("Horizontal2"), 0, Input.GetAxisRaw("Vertical2"));
        transform.rotation = Quaternion.LookRotation(LookDirection);







        //if (Input.GetKey(KeyCode.Joystick1Button2)) Sprint = true;
        if (Input.GetAxis("Left_Trigger") >= .2) Sprint = true;
       else Sprint = false;

      //  if (Input.GetKey(KeyCode.Space)) Sprint = true;
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

    void FixedUpdate()
    {
        DT = Time.deltaTime;

    
        DoMovement(RB, IPDirection, Speed, DT, MaxMovementSpeed);
        //DoMouseLook(Input.mousePosition);

        Vector3 LookDirection = new Vector3(Input.GetAxisRaw("RightHoriz"), 0, Input.GetAxisRaw("RightVert"));
        transform.rotation = Quaternion.LookRotation(LookDirection);



    }

    // Update is called once per frame
    void Update () {
       

        UpdateInput();
   
    
    }
}
