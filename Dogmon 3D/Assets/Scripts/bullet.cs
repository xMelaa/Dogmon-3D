using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour{
    
    private void OnCollisionEnter(Collision collision){        
        if (collision.gameObject.name.Contains("fence") || collision.gameObject.name.Contains("Enemy")){            
            Destroy(collision.gameObject); // Usuwanie enemy/fence przy kolizji
        }        
        Destroy(gameObject); // Usuwanie bulleta przy kolizji
    }
}