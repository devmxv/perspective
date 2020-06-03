using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    //---Unity measure before the enemy sees the player
    [SerializeField] float range;
    //[SerializeField] Transform castPoint;
    [SerializeField] float moveSpeed = 5f;


    Rigidbody2D myRigidBody2D;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < range)
        {
            //---Given the angle in rad, we transform it to Deg
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            myRigidBody2D.rotation = angle;
            //---Rotate object to player's position
            direction.Normalize();
            movement = direction;
        } else
        {
            movement = new Vector2(0, 0);
        }
        

        



        ////---check distance to player
        //

        ////print(distToPlayer);
        //if (distToPlayer < range)
        //{
        //    //---chase player
        //    ChasePlayer();
        //} else
        //{
        //    //---stop chasing player
        //    StopChasingPlayer();
        //}
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    public void moveCharacter(Vector2 direction)
    {
        myRigidBody2D.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    

    void ChasePlayer()
    {
        
       
        //if(transform.position.x < player.position.x)
        //{
        //    myRigidBody2D.velocity = new Vector2(moveSpeed, 0);
        //} else
        //{
        //    myRigidBody2D.velocity = new Vector2(-moveSpeed, 0);
        //}
    }



    void StopChasingPlayer()
    {
        //myRigidBody2D.velocity = Vector2.zero;
    }

    
}
