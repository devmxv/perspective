using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    //---Get player and reflex

    CircleCollider2D playerCollider;
    CircleCollider2D reflexCollider;


    //---Check if they are in the trigger
    //---return something?

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject reflex = GameObject.Find("Reflex");

        playerCollider = player.GetComponent<CircleCollider2D>();
        reflexCollider = reflex.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
