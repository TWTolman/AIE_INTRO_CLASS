using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    Transform TargetPos;
    Vector3 StartPos;
    float PendingShakeDuration = 0f;
    bool isShaking = false;
    [Range (0f,2f)]
    public float ShakeIntensity;
    public float Duration;

   void Start()
    {
        TargetPos = GetComponent<Transform>();
        StartPos = TargetPos.localPosition;


    }
    public void Shake(float Duration)
        
    {
        if (Duration > 0)
        {
            PendingShakeDuration += Duration;
        }

    }

    void Update()
    {
        if (PendingShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;

        var StartTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < StartTime + PendingShakeDuration)
        {

            var RandomShakePoint = new Vector3(Random.Range(-1f, 1f) * ShakeIntensity, StartPos.y, Random.Range(-1f, 1f) * ShakeIntensity);
            TargetPos.localPosition = RandomShakePoint;
            yield return null;



        }

        PendingShakeDuration = 0f;
        TargetPos.localPosition = StartPos;
     
        isShaking = false;
    }
    
        
    
}
