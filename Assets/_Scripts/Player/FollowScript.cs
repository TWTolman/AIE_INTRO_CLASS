using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {


    public GameObject FollowTarget;
    private Transform TargetTransform;
    private Transform MyTransform;
    private Rigidbody RB;

  

    public float Speed = 10;

    //public float MaxMovementSpeed = 5;

    public AnimationCurve SpeedRamp;



    // Use this for initialization
    void Start () {

        MyTransform = this.GetComponent<Transform>();
        TargetTransform = FollowTarget.GetComponent<Transform>();
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {





        Vector3 Dir = (MyTransform.position - TargetTransform.position).normalized * -1;


             Dir.y = 0;
             

             transform.forward = Dir;

        //RB.AddForce(Input * Speed * MaxSprintMultiplyer * DeltaTime);
        // rigidbody.velocity = VectorClamp(rigidbody.velocity, MaxSpeed * MaxSprintMultiplyer, MaxSpeed * MaxSprintMultiplyer, MaxSpeed * MaxSprintMultiplyer);

        float DistanceToTarget = (MyTransform.position - TargetTransform.position).magnitude;


        //RB.AddForce(Dir * Speed * SpeedRamp * Time.deltaTime);



        //RB.AddForce(Dir * Speed * Mathf.Sqrt(DistanceToTarget) * Time.deltaTime);

        RB.velocity = (Dir * Speed * Mathf.Sqrt(DistanceToTarget) * Time.deltaTime);






        ;






    }
}
