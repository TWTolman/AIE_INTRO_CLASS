using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Enemy;
    public Vector3 SpawnValues;
    public int EnemyCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;





    IEnumerator SpanWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < EnemyCount; i++)
            {


                Vector3 SpawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(Enemy, SpawnPosition, SpawnRotation);
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);

        }
    }

        
      

 

	// Use this for initialization
	void Start () {

       StartCoroutine (SpanWaves());
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}
}
