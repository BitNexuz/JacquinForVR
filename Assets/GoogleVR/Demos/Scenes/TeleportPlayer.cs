using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        print("stay");
        if (other.tag == "TpPoint")
        {
            player.transform.position = new Vector3(-9.8f, 5.25f, 4.94f);
            print("click");
        }
    }
   
}
