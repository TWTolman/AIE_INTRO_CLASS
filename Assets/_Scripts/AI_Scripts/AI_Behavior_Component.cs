using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behavior_Component : MonoBehaviour {

    private Rigidbody RB;
    private NavMeshAgent agent;
    //public GameObject Target;
    public Transform Target;
    public float attackRange;
    public GameObject HitBox;
    public float attackDelay;
    private float setAtackDelay;
    float DT;





	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Target.transform.position);

    }
	
	// Update is called once per frame
	void Update () {

        agent.destination = Target.position;
        // agent.setDestination(Target.transform.position);

        DT = Time.deltaTime;

        if ( agent.remainingDistance <= attackRange)
        {
            agent.isStopped = true;

            if (setAtackDelay <= 0)
            {
                Debug.Log("Attack");
                setAtackDelay = attackDelay;

            }

        else
            {

                agent.isStopped = false;
                agent.SetDestination(Target.transform.position);
            }
        


        }


    }
}
