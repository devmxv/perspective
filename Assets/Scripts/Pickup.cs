using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] AudioClip TreasurePickupSFX;

    public int pickupValue = 1;
    private bool coinPickedUp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Level.Instance.RegisterPickup(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Level>().AddTimeToLevel();
        AudioSource.PlayClipAtPoint(TreasurePickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
