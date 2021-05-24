using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;


public class Move : MonoBehaviour
{

    public Transform[] patrol;
    public AudioClip[] rages;
    AudioSource jacquin;
    public GameManager gm;
    public Animator anim;
    public int Currentpoint, rag;
    public float moveSpeed, stoped = 0;
    
    

   

    void Start()
    {
        jacquin = GetComponent<AudioSource>();
        transform.position = patrol[0].position;
        Currentpoint = 0;
        

        
    }
    void Update()
    {
        if (transform.position == patrol[Currentpoint].position)
        {
            Currentpoint++;
            if(Currentpoint == 5)
            {
                Currentpoint = 0;
            }
        }

        if (Currentpoint >= patrol.Length)
        {
            Currentpoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrol[Currentpoint].position, moveSpeed * Time.deltaTime);
        
        
        if(gm.statusFreezer == false && transform.position == patrol[2].position)
        {

            Currentpoint = 5;
            moveSpeed = 3;
            anim.SetBool("Run", true);
            jacquin.clip = rages[0];
            jacquin.Play();
            Invoke("randomRage", 2);
            Invoke("go", 3);
           
            
            
  

        }
        else if (gm.statusFreezer == true && transform.position == patrol[2].position)
        {

            NewMoveSpeed();
            
        }
        
        
    }

    

    public void NewMoveSpeed()
    {
        moveSpeed = Random.Range(3f, 7.5f);

    }
    public void randomRage()
    {
        rag = Random.Range(1,8);
        jacquin.clip = rages[rag];
        jacquin.Play();
    }
    public void go()
    {
        gm.gameOver();
    }

}
