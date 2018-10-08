using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour {

  
    public GameObject BulletPrefab;

    public float BulletSpeed = 500f;

    public int MaxMagCapcity;
    private int CurrentMagCapacity;

    public float MaxShootDelay;
    public float ShootDelay;

    public bool ShootText;

    float DT;
    public Transform ShootPoint;
    public float BulletLaunchVelocity = 10;
   

    public void Fire()
    {
        if (CurrentMagCapacity > 0 && ShootDelay <= 0)

        {
            Debug.Log("shoot");
            //Instantiate 

            GameObject TempBullet = Instantiate(BulletPrefab,ShootPoint.position, ShootPoint.rotation);
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
    void Start () {
        CurrentMagCapacity = MaxMagCapcity;



  




}
	
	// Update is called once per frame
	void Update () {

        DT = Time.deltaTime;
        ShootDelay -= DT;

        //Fire();
	}
}
