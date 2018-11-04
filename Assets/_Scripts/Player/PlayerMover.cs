using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    public float Speed = 10; //veriablecharacter speed

    public float MaxMovementSpeed = 5;

    public float MaxSprintMultiplyer = 2;

    private Rigidbody RB; //unity physics component

    private Vector3 IPDirection; // Input irection wordspace

    private float DT;

    public bool Sprint;

    public Camera MainCamera;

    public bool CanBurst;

    private Vector2 LastInput;
   

    private Vector2 CurrentInput;

    public float BurstForce;

    private float CamDist;

    private float LeftLimit;

    private float RightLimit;

    private float UpLimit;

    private float DownLimit;

    public GameObject ColliderWallLeft;
    public GameObject ColliderWallRight;
    public GameObject ColliderWallTop;
    public GameObject ColliderWallBottom;

    private Collider BottomWallTriggerCollider;










    //-----------------------------------------------//

    void CreateWall()
    {
        //Vector3 CenterPos = new Vector3(LeftLimit + RightLimit, DownLimit + UpLimit) / 2f;


        float ScaleX = Vector3.Distance(new Vector3(LeftLimit, 0, 0), new Vector3(RightLimit, 0, 0));
        float ScaleZ = Vector3.Distance(new Vector3(0, DownLimit, 0), new Vector3(0, UpLimit, 0)); 

        //TOP WALL
        Instantiate(ColliderWallTop);
   
        ColliderWallTop.transform.position = new Vector3(0, 0, UpLimit);
        ColliderWallTop.transform.localScale = new Vector3(ScaleX,10, 1);

        //LEFT WALL
        Instantiate(ColliderWallLeft);

        ColliderWallLeft.transform.position = new Vector3(RightLimit, 0, 0);
        ColliderWallLeft.transform.localScale = new Vector3(1, 10, ScaleZ);

        //RIGHT WALL
        Instantiate(ColliderWallRight);

        ColliderWallRight.transform.position = new Vector3(LeftLimit, 0, 0);
        ColliderWallRight.transform.localScale = new Vector3(1, 10, ScaleZ);

        //Bottom WALL
        Instantiate(ColliderWallBottom);

        ColliderWallBottom.transform.position = new Vector3(0, 0, DownLimit);
        ColliderWallBottom.transform.localScale = new Vector3(ScaleX, 10, 1);

       // BottomWallTriggerCollider = GetComponent<Collider>();
       // BottomWallTriggerCollider.isTrigger = true;








    }


    void ScreenClamp()
    {
         CamDist = (transform.position.y - Camera.main.transform.position.y) - 4 ;

         LeftLimit = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0,CamDist)).x;
        
         RightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, CamDist)).x;

         UpLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, CamDist)).z;
         DownLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, CamDist)).z;


       

      gameObject.transform.position = new Vector3 
             (Mathf.Clamp(transform.position.x, RightLimit , LeftLimit), 
             gameObject.transform.position.y,
             Mathf.Clamp(transform.position.z, DownLimit, UpLimit));


        










    }

    public void DoBurstPush()

        

    {
        CurrentInput = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
        
        
        //if ((Input.GetAxisRaw("Horizontal2") > 0.2f) || (Input.GetAxisRaw("Vertical2") > 0.2f))


        if (CurrentInput.magnitude > 0.2f)

        {
            CanBurst = true;
            RB.velocity = new Vector3 (0,0,0);
        }

       
        if (CanBurst && CurrentInput.magnitude < 0.2f && LastInput.magnitude > 0.2f)



        {
            Vector3 _tempV3 = new Vector3(LastInput.normalized.x * -1, 
                                          0,
                                          LastInput.normalized.y * -1);
            RB.AddForce (_tempV3 * BurstForce , ForceMode.Impulse);
            CanBurst = false;
        }



        if (CurrentInput.magnitude > 0.2f)
        {
            LastInput = CurrentInput;
        }
    }





    // Use this for initialization
    void Start () {

        RB = GetComponent<Rigidbody>();
        ScreenClamp();
        CreateWall();
    }


   

    void DoLookDirection()

    {
        float H2 = Input.GetAxisRaw("Horizontal2");
        float V2 = Input.GetAxisRaw("Vertical2");


        Vector3 LookDirection = new Vector3(LastInput.x, 0, LastInput.y);

        //Vector3 LookDirection = new Vector3(Input.GetAxisRaw("Horizontal2"), 0, Input.GetAxisRaw("Vertical2"));
        transform.rotation = Quaternion.LookRotation(LookDirection);

        

     

    }

void UpdateInput()
    {



     //   if (!CanBurst)
       // {
            IPDirection.x = Input.GetAxisRaw("Horizontal");
            IPDirection.z = Input.GetAxisRaw("Vertical");
        //Debug.Log("x: " + IPDirection.x + "\n z: " + IPDirection.z);


        if (IPDirection.x > 0.2f || IPDirection.z > 0.2f)
            {
                RB.velocity = new Vector3(0, 0, 0);
            //       CanBurst = true;
            //Debug.Log("x: "+ IPDirection.x +"\n z: "+ IPDirection.z);
         //   }


        }





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
         

        if (Sprint == true)
        {
            transform.position += (Input * Speed *2 * DeltaTime);

        }
        else
        {
            transform.position += (Input * Speed * DeltaTime);

        }


            //ridgidbody.velocity = new Vector3(Mathf.Clamp(rigidbody.velocity.x, -MaxSpeed, MaxSpeed), RB.velocity.y,
            // Mathf.Clamp(rigidbody.velocity.z, -MaxSpeed, MaxSpeed)); 



            //if (Sprint == true)
            // {
            //     RB.AddForce(Input * Speed * MaxSprintMultiplyer * DeltaTime);
            //     rigidbody.velocity = VectorClamp(rigidbody.velocity, MaxSpeed * MaxSprintMultiplyer, MaxSpeed * MaxSprintMultiplyer, MaxSpeed * MaxSprintMultiplyer);
            // }

            //else
            // {


            //RB.AddForce(Input * Speed * DeltaTime);
            // rigidbody.velocity = VectorClamp(rigidbody.velocity, MaxSpeed, MaxSpeed, MaxSpeed);



            //}
    }


   

   

    void FixedUpdate()
    {
        DT = Time.deltaTime;

    
        DoMovement(RB, IPDirection, Speed, DT, MaxMovementSpeed);
        //DoMouseLook(Input.mousePosition);

        //Vector3 LookDirection = new Vector3(Input.GetAxisRaw("RightHoriz"), 0, Input.GetAxisRaw("RightVert"));
        //transform.rotation = Quaternion.LookRotation(LookDirection);

        UpdateInput();
        DoLookDirection();
        DoBurstPush();
       

    }

    // Update is called once per frame
    void Update () {

        ScreenClamp();






    }
}
