using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeTest : MonoBehaviour {


    public Shaker Shaker;
    public float duration = 1f;



   void OnCollisionEnter(Collision collision)
    {
        Shaker.Shake(duration);
    }
 //   void Update ()
 //   {
	//	if (Input.GetKeyDown(KeyCode.Space))
 //       {
 //           Shaker.Shake(duration);
 //       }
	//}
}
