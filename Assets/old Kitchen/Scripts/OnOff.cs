using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public MeshRenderer color;
    public GameManager gm;
    public Move player;
    public Material Green;
    public Material Red;
    public float time, maxTime = 1;
    public GameObject playerBody;
   

    public void Start()
    {
        gm.f1 = true;
        gm.f2 = true;
    }
    private void OnTriggerStay(Collider other)
    {
        
        time += 1 * Time.deltaTime;
        if(time >= maxTime)
        {
            time = maxTime;          
        }

        if (other.CompareTag("Cam") && time == maxTime)
        {
            if (this.gameObject.CompareTag("Freezer1") && gm.f1 == true)
            {
                gm.f1 = false;
                color.material = Red;
                time = 0;
            }
            
            else if (this.gameObject.CompareTag("Freezer1") && gm.f1 == false)
            {
                gm.f1 = true;
                color.material = Green;
                time = 0;
            }
        
            if (this.gameObject.CompareTag("Freezer2") && gm.f2 == true)
            {
                gm.f2 = false;
                color.material = Red;
                time = 0;
            }
            else if (this.gameObject.CompareTag("Freezer2") && gm.f2 == false)
            {

                gm.f2 = true;
                color.material = Green;
                time = 0;
            }
            if(this.gameObject.CompareTag("PlayAgain"))
            {
                gm.playAgain();
            }
            if (this.gameObject.CompareTag("Quit"))
            {
                gm.toMenu();
            }
            if (this.gameObject.CompareTag("QuitGame"))
            {
                gm.end();
            }
            if (Input.GetMouseButton(1)){
                player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.x);
            }

        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cam"))
        {
            time = 0;
        }
    }
}
