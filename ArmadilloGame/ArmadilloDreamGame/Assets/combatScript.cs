using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour {
    enum enemyStates
    {
        IDLE,
        ATTACKING,
        MISSED,
        RANDOMATTACK
    }
    float armadilloSpeed = 4.0f;
    Vector3 direction;
    Vector3 centerIsland;
    public static float distanceFromCenter = 50.0f;
    public Vector3 currentPlayerPos;// = 
    Vector3 rotationDirection;
    Vector3 rotateToPlayerPos;
    Vector3 zeroVec;

  
    enemyStates bossStates;
	// Use this for initialization
	void Start ()
    {
        zeroVec = new Vector3(0, 0, 0);
        currentPlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        centerIsland = new Vector3(255,15,255);
        rotateToPlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        rotationDirection = rotateToPlayerPos;
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
        while (transform.position != currentPlayerPos) 
        {
            this.transform.position += transform.forward * armadilloSpeed * Time.deltaTime;
            rotationDirection = new Vector3(0,0,0);
        }
        //   yield return new WaitForSeconds(3);
        //Vector3 tempCurrentPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        direction.x = 0;
        direction.y = 0;
        direction.z = 0;


    }

    void armadilloRotate()
    {
        direction.y = 0;
      //  rotationDirection = 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotationDirection), 0.5f);


    }


    void armadilloStates(enemyStates states)
    {
        switch(states)
        {
            case enemyStates.IDLE:
                {
                    armadilloSpeed = 0;
                }
                break;
            case enemyStates.ATTACKING:
                {
                    armadilloSpeed = 5;
                    armadilloRotate();
                    armadilloAttackPlayer();
                }
                break;
            case enemyStates.MISSED:
                {
                    armadilloSpeed = 0;
                }
                break;
            case enemyStates.RANDOMATTACK:
                {

                }
                break;
            default:
                armadilloRotate();
                break;
          //  default: enemyStates.IDLE

        }
    }

}
