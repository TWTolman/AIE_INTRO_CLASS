using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Component : MonoBehaviour
{


    public float Damage = 25.0f;



    //void OnCollisionEnter(Collider other)
    //{

    //    if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ship")



    //    Debug.Log("collision happend");
    //    ObjectHealth Health = other.GetComponent<ObjectHealth>();
    //    {

    //        if (Health != null)

    //        {
    //            Health.TakeDamage(Damage);
    //        }

    //    }
    //}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ship") 

        {

            Debug.Log("collision happend");

            ObjectHealth Health = other.gameObject.GetComponent<ObjectHealth>();
           // ObjectHealth Health = other.GetComponent<ObjectHealth>();
            {

                if (Health != null)

                {
                    Health.TakeDamage(Damage);
                }

            }



        }



    }
}

