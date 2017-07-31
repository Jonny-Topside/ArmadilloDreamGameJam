using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour {
    float armadilloSpeed = 4.0f;
    Vector3 direction;
    Vector3 centerIsland;
    public static float distanceFromCenter = 50.0f;
	// Use this for initialization
	void Start ()
    {
		centerIsland = new Vector3(255,15,255);
	}
	
	// Update is called once per frame
	void Update () {
        armadilloRotate();
        armadilloAttackPlayer();
        // ifArmadilloMisses();
        if (Vector3.Distance(centerIsland, transform.position) > distanceFromCenter)
        {
            transform.position = transform.position;
        }
    }

    void ifArmadilloMisses()
    {
        //armadillo will do a fury bounce three times
        for(uint i = 0; i < 3; i++)
        {
       //     transform.position += (transform.position.y + 3) * Time.deltaTime;
    //    transform.position.Set(transform.position.x, transform.position.y + 3, transform.position.z);
            transform.position += new Vector3(transform.position.x, transform.position.y + 3, transform.position.z) * Time.deltaTime * armadilloSpeed;
         //   yield return new WaitForSeconds(3);
        }

       //why doesn't this work?
        // transform.position.y += 3;

       // return true;
    }

    void armadilloAttackPlayer()
    {
        this.transform.position += transform.forward * armadilloSpeed * Time.deltaTime;
     //   yield return new WaitForSeconds(3);

    }

    void armadilloRotate()
    {
        direction.y = 0;
        
        Vector3 rotationDirection = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotationDirection), 0.5f);

    }


}
