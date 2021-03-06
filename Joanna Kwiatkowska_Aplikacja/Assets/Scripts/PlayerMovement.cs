using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
    
    public CharacterController controller; 
    public Transform cam; // zmiana kamery
    public GameObject deathMenu;

    public float speed = 5f; //zmienna szybkości
    public float turnSmoothTime = 0.1f; //zmienna gładkości zmiany kierunku
    float turnSmoothVelocity;

    public float energia = 1; //energia

    void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal"); //zmienne odpowioedzialne za poruszanie sie wsad i strzalkami
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //poruszanie sie po x i po z, po y zablokowane 
                                                            // normalized - szybkosc poruszania sie na ukos nie podwaja sie 
        if (direction.magnitude>= 0.1f){ //jezeli dlugosc wektora jest wieksza lub rowna 0.1
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //gładkie przechodzenie

            transform.rotation = Quaternion.Euler(0f, angle, 0f); //obrót gracza w te strone, w ktore idzie

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized *speed*Time.deltaTime); //poruszaj się
        }                                                     
    }

    public void energy(int wartosc){
        energia = energia + wartosc; //dodawanie wartosci do energii        
    } 
}
