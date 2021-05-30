using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour{
    public Transform target;
    public float speed = 4f;
    private Rigidbody rig;
    public PlayerMovement player;
    
    private void Start(){
        rig = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement> ();
    }
    
    private void Update(){
        var pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision collision){        
        if (collision.gameObject.name.Contains("Player")){
            player.energy (-1);
        }
    }
}