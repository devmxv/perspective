using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BossEnemy : MonoBehaviour
{
    [SerializeField] AudioClip bossDeathSFX;
    public static bool bossActive;
    private bool isBossDestroyed;
    
    
    
    Rigidbody2D bossRigidBody2d;
    
    // Start is called before the first frame update
    void Start()
    {
        bossActive = true;
        bossRigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleBossFight();
    }


    //---Reduce the speed each time an item is picked up
    public void HandleBossFight()
    {
        int pickUps = FindObjectOfType<Level>().RemainingPickups();
        //Debug.Log("Pickups from boss: " + pickUps);

        //---Reduce speed of the boss
        if(pickUps == 0)
        {
            //---WIP: Reduce the movement velocity
            //bossRigidBody2d.velocity = Vector2.zero;
            AudioSource.PlayClipAtPoint(bossDeathSFX, Camera.main.transform.position);
            Destroy(gameObject);
        } 

    }

    
}
