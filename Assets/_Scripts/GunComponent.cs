using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{


    public GameObject BulletPrefab;

    public float BulletSpeed = 500f;

    public int MaxMagCapcity;
    public int CurrentMagCapacity;

    public float MaxShootDelay;
    public float ShootDelay;

    public bool ShootText;
    public bool ReloadCheck;

    float DT;
    public Transform ShootPoint;
    public float BulletLaunchVelocity = 10;


 


    public void Reload()
    {
        if (Input.GetKey(KeyCode.LeftShift) && CurrentMagCapacity <= 0 ) ReloadCheck = true;
           else ReloadCheck = false;

        if (ReloadCheck == true)

        {

            Debug.Log("RELOADED");
            CurrentMagCapacity = MaxMagCapcity;


        }

    }

    //if (CurrentMagCapacity <= 0 ) (Input.GetKey(KeyCode.LeftShift)) ;





    public void Fire()
    {
        if (CurrentMagCapacity > 0 && ShootDelay <= 0)

        {
            Debug.Log("shoot");
            //Instantiate 

            GameObject TempBullet = Instantiate(BulletPrefab, ShootPoint.position, ShootPoint.rotation);
            TempBullet.GetComponent<Rigidbody>().velocity = ShootPoint.forward * BulletLaunchVelocity;
            Destroy(TempBullet, 4.0f);



            //  GameObject clone;
            // clone = Instantiate(BulletPrefab, transform.position, transform.rotation) as GameObject;
            // clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 10);


            ShootDelay = MaxShootDelay;
            CurrentMagCapacity--;

        }

        //BulletPrefab = Instantiate (BulletPrefab, transform.position, transform.rotation) as GameObject;
        //BulletSpeed = transform.TransformDirection(Vector3.forward * 10)

        else if (CurrentMagCapacity <= 0)
        {
            Debug.Log("empty");
        }



        //if (Input.GetKey(KeyCode.LeftShift)) ShootText = true;
        //    else ShootText = false;

        // if (ShootText == true)
        // {

        //Debug.Log("shoot");

        //}



    }

    // Use this for initialization
    void Start()
    {
        CurrentMagCapacity = MaxMagCapcity;
    }



    // Update is called once per frame
    void Update()
    {

        DT = Time.deltaTime;
        ShootDelay -= DT;

        //Fire();

        Reload();

    }


}
    
