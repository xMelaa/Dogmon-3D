using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneRotation : MonoBehaviour{
    public GameObject kosc; 
    float speed = 70.0f; 
    
    void Update(){
        kosc.transform.Rotate(Vector3.up * speed * Time.deltaTime);        
    }
}
