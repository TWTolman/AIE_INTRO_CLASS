using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFreeze : MonoBehaviour {

    public float FreezeDuration = 1f ;
    float PendingFreezeDuration = 0f;
    bool isFrozen = false;


    
    void OnCollisionEnter(Collision collission)
    {
        Debug.Log(collission.collider.name);
        StartCoroutine(DoFreeze());
        
    }

    public void TimeFreezeReset()
    {
        PendingFreezeDuration = FreezeDuration;


    }

    IEnumerator DoFreeze()
    {
        Debug.Log("freeze");
        isFrozen = true;
        var Origonal = Time.timeScale;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(FreezeDuration);
        Debug.Log("yeild return!");
        Time.timeScale = Origonal;

        PendingFreezeDuration = 0;
    

        isFrozen = false;

    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PendingFreezeDuration < 0 && !isFrozen)
            {
            StartCoroutine(DoFreeze());
;
        }

		
	}
}
