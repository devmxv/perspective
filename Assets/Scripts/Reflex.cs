using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflex : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] AudioClip reflexDieSFX;

    Rigidbody2D myRigidBody;
    Rigidbody2D reflexRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //---Right switched to left
        {
            //buttonPressed = RIGHT;
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
            //reflexRigidBody.transform.position -= transform.right * (Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //---Left switched to Right
        {
            //buttonPressed = LEFT;
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
            //reflexRigidBody.transform.position += transform.right * (Time.deltaTime * moveSpeed);

        }
        else if (Input.GetKey(KeyCode.DownArrow)) //---Up switched to Down
        {
            transform.position += transform.up * (Time.deltaTime * moveSpeed);
            //reflexRigidBody.transform.position -= transform.up * (Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.UpArrow)) //---Down switched to Up
        {
            transform.position -= transform.up * (Time.deltaTime * moveSpeed);
            //reflexRigidBody.transform.position += transform.up * (Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Equals("Alter Ego"))
        {
            AudioSource.PlayClipAtPoint(reflexDieSFX,Camera.main.transform.position);
            Destroy(gameObject);
            FindObjectOfType<Level>().ShowGameOver();
        }
        
    }
}
