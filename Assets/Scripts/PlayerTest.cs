using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    public bool isGrounded = false;

    Rigidbody2D myRigidBody;
    Rigidbody2D reflexRigidBody;

    


    // Start is called before the first frame update
    void Start()
    {
        GameObject reflex = GameObject.Find("Reflex");
        reflexRigidBody = reflex.GetComponent<Rigidbody2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        //Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, myRigidBody.velocity.y);

        //myRigidBody.velocity = movement;

        //bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0);
            reflexRigidBody.velocity = new Vector2(-moveSpeed, 0);

        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0);
            reflexRigidBody.velocity = new Vector2(moveSpeed, 0);
        }
        
        
    }
}
