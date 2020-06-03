using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ReturnToMainMenu());
    }

    IEnumerator ReturnToMainMenu()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            yield return new WaitForSeconds(2);
            FindObjectOfType<LevelLoader>().LoadStartMenu();
        }
    }
}
