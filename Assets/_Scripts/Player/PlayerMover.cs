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

   
    public Collider PirateShipCollider;
    public Collider PlayerCollider;

    public float AttackForceAmmount;



    //-----------------------------------------------//



    //}

    //public void DoBurstPush()

        

    //{
    //    CurrentInput = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
        
        
    //    //if ((Input.GetAxisRaw("Horizontal2") > 0.2f) || (Input.GetAxisRaw("Vertical2") > 0.2f))


    //    if (CurrentInput.magnitude > 0.2f)

    //    {
    //        CanBurst = true;
    //        RB.velocity = new Vector3 (0,0,0);
    //    }

       
    //    if (CanBurst && CurrentInput.magnitude < 0.2f && LastInput.magnitude > 0.2f)



    //    {
    //        Vector3 _tempV3 = new Vector3(LastInput.normalized.x * -1, 
    //                                      0,
    //                                      LastInput.normalized.y * -1);
    //        RB.AddForce (_tempV3 * BurstForce , ForceMode.Impulse);
    //        CanBurst = false;
    //    }



    //    if (CurrentInput.magnitude > 0.2f)
    //    {
    //        LastInput = CurrentInput;
    //    }
    //}





    // Use this for initialization
    void Start () {


     

        RB = GetComponent<Rigidbody>();
        //ScreenClamp();
        //CreateWall();

       // PirateShipCollider = GameObject.FindGameObjectWithTag("Ship").GetComponent<Collider>();
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();

       // Physics.IgnoreCollision(PirateShipCollider, PlayerCollider, true);
    }

    public void AttackAction()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("Button press");
            Collider[] EnemyColliders = Physics.OverlapSphere(gameObject.transform.position,1.5f);
           
            for (int i = 0; i < EnemyColliders.Length; i++)
            {
                EnemyMover AttackedEnemy = EnemyColliders[i].GetComponent<EnemyMover>();

                if (AttackedEnemy != null)
                    AttackedEnemy.EnemyLaunch(Vector3.forward * AttackForceAmmount);
            }   
        }



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
              //  RB.velocity = new Vector3(0, 0, 0);
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
        //DoBurstPush();
       

    }

    // Update is called once per frame
    void Update () {

        AttackAction();

        //ScreenClamp();






    }
}
