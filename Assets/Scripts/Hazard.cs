using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] AudioClip playerDamageSFX;

    //public Player player;
    public CameraShake cameraShake;
    Rigidbody2D playerRb2d;
    private float shakeForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerRb2d = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Level>().ReduceTimeToLevel();
        AudioSource.PlayClipAtPoint(playerDamageSFX, Camera.main.transform.position);
        ShakePlayer();
        Debug.Log("Time reduced!");
    }

    //---Shakes the camera as a feedback to player when damaged
    public void ShakePlayer()
    {
        
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        //---TODO: Bounce player after damage
        //playerRb2d.AddForce(new Vector2(1,1) * shakeForce, ForceMode2D.Impulse);
    }



}
