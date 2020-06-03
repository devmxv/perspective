using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    //---TODO: This should be in the Level script since controls the behaviour here
    [SerializeField] GameObject infoMessage;
    [SerializeField] AudioClip playerDieSFX;
    [SerializeField] AudioClip warpZoneSFX;

    Rigidbody2D myRigidBody;
    Rigidbody2D reflexRigidBody;
    CircleCollider2D myBodyCollider;
    CircleCollider2D reflexCollider;
    //private int pickUps;
    Vector2 movement;
    BossEnemy boss;
    private bool warpActive;
    private static bool bossIsActive;


    // Start is called before the first frame update
    void Start()
    {
        warpActive = false;
        GameObject reflex = GameObject.Find("Reflex");
        reflexRigidBody = reflex.GetComponent<Rigidbody2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CircleCollider2D>();
        reflexCollider = reflex.GetComponent<CircleCollider2D>();
        //---Set info message panel initially off
        infoMessage.SetActive(true);

        


    }

    // Update is called once per frame
    void Update()
    {
        bossIsActive = BossEnemy.bossActive;
        


        //Input
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        PlayersInWarp();
        Die();

        
        

    }

    private void FixedUpdate()
    {
        //Movement
        //myRigidBody.MovePosition(myRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        Move();
    }

    private void Move()
    {
        //---Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //buttonPressed = RIGHT;
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
            //reflexRigidBody.transform.position -= transform.right * (Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //---Left
        {
            //buttonPressed = LEFT;
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
            //reflexRigidBody.transform.position += transform.right * (Time.deltaTime * moveSpeed);
            
        } else if (Input.GetKey(KeyCode.UpArrow)) //---Up
        {
            transform.position += transform.up * (Time.deltaTime * moveSpeed);
            //reflexRigidBody.transform.position -= transform.up * (Time.deltaTime * moveSpeed);
        } else if (Input.GetKey(KeyCode.DownArrow)) //---Down
        {
            transform.position -= transform.up * (Time.deltaTime * moveSpeed);
            //reflexRigidBody.transform.position += transform.up * (Time.deltaTime * moveSpeed);
        }
    }

    //---Once the player and reflex meet, the level is over
    //---Next level should be loaded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (!bossIsActive)
        {
            Debug.Log("Boss fight!: " + bossIsActive);
            //---Retrieve the pickups in the arena
            int pickUps = FindObjectOfType<Level>().RemainingPickups();
            //print(pickUps);
            if (collision.gameObject.name == "Reflex" && pickUps == 0 && warpActive)
            {
                Debug.Log("Go to next level!");
                AudioSource.PlayClipAtPoint(warpZoneSFX, Camera.main.transform.position);
                FindObjectOfType<LevelLoader>().LoadNextScene();

            }
            else if ((collision.gameObject.name != "Foreground" || collision.gameObject.name != "Borders") && pickUps >= 1)
            {
                Debug.Log("Collision in borders and blocks");
                infoMessage.SetActive(true);
            }
        } else
        {
            //---Boss fight conditions here
            bool bossKilled = FindObjectOfType<Level>().BossDestroyed();
            
            if (collision.gameObject.name == "Reflex" && warpActive && bossKilled)
            {
                Debug.Log("Go to next level!");
                AudioSource.PlayClipAtPoint(warpZoneSFX, Camera.main.transform.position);
                FindObjectOfType<LevelLoader>().LoadNextScene();

            }
        }
        

    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.name == "Warp Zone")
    //    {
    //        Debug.Log("Next level!");
    //    }
    //}

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy"))){
            AudioSource.PlayClipAtPoint(playerDieSFX, Camera.main.transform.position);
            
            Destroy(gameObject);
            //FindObjectOfType<Level>().ShowGameOver();
            Level.Instance.ShowGameOver();

        }
    }

    //---Checks if both players are in the warp zone to move to the next level
    public void PlayersInWarp()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Warp")) && reflexCollider.IsTouchingLayers(LayerMask.GetMask("Warp")))
        {
            Debug.Log("Warp active!");
            
            warpActive = true;
        }
    }



}
