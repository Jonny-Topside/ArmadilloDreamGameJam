using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour {
    int armadilloSpeed = 2;
    Vector3 direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



    }

    void ifArmadilloMisses()
    {
        //armadillo will do a fury bounce three times
        transform.position.Set(transform.position.x, transform.position.y + 3, transform.position.z);
       //why doesn't this work?
        // transform.position.y += 3;

       // return true;
    }

    void armadilloAttackPlayer()
    {
        this.transform.position += this.transform.forward * armadilloSpeed * Time.deltaTime;


    }

    void armadilloRotate()
    {
        direction.y = 0;
        Vector3 rotationDirection = GameObject.FindGameObjectWithTag("Player").transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(rotationDirection), 0.2f);

    }


}
