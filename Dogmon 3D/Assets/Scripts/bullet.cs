using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.name.Contains("fence") || collision.gameObject.name.Contains("Enemy"))
        {
            // Usuwanie enemy/fence przy kolizji
            Destroy(collision.gameObject);
        }
        // Usuwanie bulleta przy kolizji
        Destroy(gameObject);
    }
}