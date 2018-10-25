using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{


    public GameObject BulletPrefab;
    public GameObject ReloadText;

    public float BulletSpeed = 500f;

    public int MaxMagCapcity;
    public int CurrentMagCapacity;

    public float MaxShootDelay;
    public float ShootDelay;

    public bool ShootText;
    public bool ReloadCheck;
    public bool CreateText;
    public GameObject SpeechBuble;

    float DT;
    public Transform ShootPoint;
    public Transform PlayerText;
    public float BulletLaunchVelocity = 10;
    //public bool BulletExists;


 
    public void CreateReloadText()

    {

       if (CreateText = false && (CurrentMagCapacity <= 0 ))
            Instantiate(ReloadText, transform);
            CreateText = true;

    }


    public void Reload()
    {

        if (Input.GetKey(KeyCode.Joystick1Button3) && CurrentMagCapacity <= 0) ReloadCheck = true;
        else ReloadCheck = false;

        //if (Input.GetKey(KeyCode.LeftShift) && CurrentMagCapacity <= 0 ) ReloadCheck = true;
        //else ReloadCheck = false;

        if (ReloadCheck == true)

        {

            Debug.Log("RELOADED");
            CurrentMagCapacity = MaxMagCapcity;
            SpeechBuble.SetActive(false);

        }

     }


    

public void Fire()
    {
        if (CurrentMagCapacity > 0 && ShootDelay <= 0)

        {
            Debug.Log("shoot");
            //Instantiate 

            GameObject TempBullet = Instantiate(BulletPrefab, ShootPoint); 
            //Instantiate(BulletPrefab, ShootPoint.position, ShootPoint.rotation);

           
            TempBullet.GetComponent<Rigidbody>().velocity = ShootPoint.forward * BulletLaunchVelocity;

            transform.parent = null;


            //gameObject.transform.SetParent(null);


            //gameObject.transform.parent = null;

            TempBullet.GetComponent<BulletScript>().Owner = gameObject;
            Destroy(TempBullet, 10.0f);

            ShootDelay = MaxShootDelay;
            CurrentMagCapacity--;

           

            //  GameObject clone;
            // clone = Instantiate(BulletPrefab, transform.position, transform.rotation) as GameObject;
            // clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 10);

        }

        //BulletPrefab = Instantiate (BulletPrefab, transform.position, transform.rotation) as GameObject;
        //BulletSpeed = transform.TransformDirection(Vector3.forward * 10)

        else if (CurrentMagCapacity <= 0 )
        {

            //Instantiate(ReloadText, transform);

            //GameObject Temp_ReloadText = Instantiate(ReloadText, PlayerText.position, PlayerText.rotation);
            Debug.Log("empty");

            SpeechBuble.SetActive  (true);

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
        SpeechBuble.SetActive (false);
        
    }



    // Update is called once per frame
    void Update()
    {
        CreateReloadText();
        DT = Time.deltaTime;
        ShootDelay -= DT;

        //Fire();

        Reload();

    }


}
    
