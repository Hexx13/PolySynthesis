using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class egghunt : MonoBehaviour
{
    //old code from tutorial
    private int challengeStatus = 0;
    private bool playerLeftSpawn = false;
    private int challengeCount = 0;


    //old code from tutorial
    public TextMeshPro scoreText;
    public AudioClip[] voiceoverSound;
    public AudioSource tutorialPlayer;
    public GameObject [] portals;
    private BoxCollider collider;
    // easter egg array
    public GameObject [] eggs;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //tutorial();
    }


    private void OnTriggerEnter(Collider collision)
    {
        for(int i = 0; i < eggs.Length; i++)
            if(collision.gameObject.Equals(eggs[i])){
                challengeCount++;
                Debug.Log("Pouch enter");
            }
        Debug.Log("Collision enter");
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Plaer"))Debug.Log("player left spawn");//playerLeftSpawn = true;
        

        if(collision.gameObject.Equals(eggs[0])){
            challengeCount--;
            Debug.Log("Pouch exit");
        }else if(collision.gameObject.Equals(eggs[1])){
            challengeCount--;
            Debug.Log("Red Shroom exit");
        }else if(collision.gameObject.Equals(eggs[2])){
            challengeCount--;
            Debug.Log("Purple Shroom exit");
        }
        Debug.Log("Collision eexit");
    }


    private void tutorial(){
        switch(challengeStatus){
            case 0:
                challenge1();
                if(playerLeftSpawn)challengeStatus++;
                break;
        
            case 1:
                challenge2();
                challengeStatus++;
                break;
                //make unity wait a few seconds

            case 2:
                challenge3();
                break;
        }


    }




    private void challenge1(){
        //intro voiceover
        tutorialPlayer.PlayOneShot(voiceoverSound[0]);
            //How to look around Voicover
            //How To move
            //how to jump
            

        


    }
    private void challenge2(){
        tutorialPlayer.PlayOneShot(voiceoverSound[1]);
        //how to pick up things voice over
        

    }
    private void challenge3(){
        tutorialPlayer.PlayOneShot(voiceoverSound[2]);
        scoreText.SetText("Items Collected " + challengeCount + "/3");
        if(challengeCount >= 3){
            for(int i = 0; i < portals.Length; i++)
            portals[i].SetActive(true);
        }
    }
}