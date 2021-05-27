using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fence : MonoBehaviour{
    public PlayerMovement player;    
    
    void Start(){
        player = FindObjectOfType<PlayerMovement> (); //automatycznie przypisz obiekt        
    }

    void OnTriggerEnter(Collider col){ //jesli wejdzie na pole    
        if(col.name== "Player"){ //jesli colider to player i teleport jest true           
           Destroy(gameObject);             
        }
    }    
}
