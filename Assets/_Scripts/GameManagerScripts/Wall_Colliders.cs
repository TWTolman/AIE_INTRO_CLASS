using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Colliders : MonoBehaviour {



    private float CamDist;

    private float LeftLimit;

    private float RightLimit;

    private float UpLimit;

    private float DownLimit;

    public GameObject ColliderWallLeft;
    public GameObject ColliderWallRight;
    public GameObject ColliderWallTop;
    public GameObject ColliderWallBottom;
    public GameObject PirateShip;
    public GameObject FocusPointForCameraDistance;

    private Collider BottomWallTriggerCollider;



    void CreateWall()
    {
        //Vector3 CenterPos = new Vector3(LeftLimit + RightLimit, DownLimit + UpLimit) / 2f;


        float ScaleX = Vector3.Distance(new Vector3(LeftLimit, 0, 0), new Vector3(RightLimit, 0, 0));
        float ScaleZ = Vector3.Distance(new Vector3(0, DownLimit, 0), new Vector3(0, UpLimit, 0));

        //TOP WALL
        Instantiate(ColliderWallTop);

        ColliderWallTop.transform.position = new Vector3(0, 0, UpLimit);
        ColliderWallTop.transform.localScale = new Vector3(ScaleX, 10, 1);

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

        ColliderWallBottom.transform.position = new Vector3(0, 0, DownLimit - 4);
        ColliderWallBottom.transform.localScale = new Vector3(ScaleX, 10, 1);


        //Ship 

        Instantiate(PirateShip);
        PirateShip.transform.position = new Vector3(0, -7, DownLimit - 7f);

        // BottomWallTriggerCollider = GetComponent<Collider>();
        // BottomWallTriggerCollider.isTrigger = true;


    }


    void ScreenClamp()

    //PlayerMover playerMover = 

    {
       
        CamDist = (FocusPointForCameraDistance.transform.position.y  - Camera.main.transform.position.y) - 3;

        LeftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, CamDist)).x;

        RightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, CamDist)).x;

        UpLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, CamDist)).z;
        DownLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, CamDist)).z;




        gameObject.transform.position = new Vector3
               (Mathf.Clamp(transform.position.x, RightLimit, LeftLimit),
               gameObject.transform.position.y,
               Mathf.Clamp(transform.position.z, DownLimit, UpLimit));

    }





        // Use this for initialization
        void Start ()

        {


        ScreenClamp();


        CreateWall();

       
    }
	
	// Update is called once per frame
	void Update () {

        


    }
}
