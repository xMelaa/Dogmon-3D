using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Coins : MonoBehaviour{
    public PlayerMovement player;      
    public bool teleport = false;    
        //Aktualna ilość punktów
    private int coin = 0;
    private int coinLVL = 0;
    public int lvlNumber = 0;
        //Pobieramy muzykę do coinSound
    public AudioClip coinSound;
        //Głośność muzyki
    public float volume;
        //Pobieramy TextMeshPro do textCoins
    public TextMeshProUGUI textCoins;
        //W trakcie kolizji, algorytm sam wylicza ile jest i ile powinno 
        //być punktów, nie trzeba zmieniać
 
    void Start(){
        player = FindObjectOfType<PlayerMovement> (); //automatycznie przypisz obiekt        
        lvlNumber = SceneManager.GetActiveScene().buildIndex;

        switch (lvlNumber)
                {
                    case 1:
                        coinLVL = 10;
                        break;
                    case 2:
                        coinLVL = 12;
                        break;
                    case 3:
                        coinLVL = 56;
                        break;
                    case 4:
                        coinLVL = 26;
                        break;
                    case 5:
                        coinLVL = 40;
                        break;
                    case 6:
                        coinLVL = 45;
                        break;
                    case 7:
                        coinLVL = 24;
                        break;
                    case 8:
                        coinLVL = 44;
                        break;
                    case 9:
                        coinLVL = 62;
                        break;
                    default:
                        break;
                }

                textCoins.text = coin.ToString() + " / " + coinLVL;

    }   

    void OnTriggerEnter(Collider col){ //jesli wejdzie na pole    
        if(col.tag== "Coins"){ //jesli colider to player i teleport jest true           
           Destroy(col.gameObject);           
        }

        switch (lvlNumber){
                    case 1:
                        coinLVL = 10;
                        break;
                    case 2:
                        coinLVL = 12;
                        break;
                    case 3:
                        coinLVL = 56;
                        break;
                    case 4:
                        coinLVL = 26;
                        break;
                    case 5:
                        coinLVL = 42;
                        break;
                    case 6:
                        coinLVL = 62;
                        break;
                    case 7:
                        coinLVL = 24;
                        break;
                    case 8:
                        coinLVL = 44;
                        break;
                    case 9:
                        coinLVL = 64;
                        break;
                    default:
                        break;
                }

            if (col.gameObject.tag == "Coins"){                
                coin++; //powiększ coin o 1
                
                if(coin==coinLVL){ //jeśli osiągniemy ilość punktów do przejścia na kolejny poziom to odblokuj teleport
                    teleport = true;                    
                }
                textCoins.text = coin.ToString() + " / " + coinLVL;//zmien wczesniej wybrany TextMeshPro na Tekst + ilość punktów zamienionych na string                
                    
                Vector3 colPosition = col.transform.position; //tworzymy Vector3 z miejscem kolizji                  
                
                AudioSource.PlayClipAtPoint(coinSound, colPosition, volume); //Odtwórz dźwięk coinSound w miejscu kolizji
                    //Zniszcz obiekt
                //Destroy(gameObject);
            }
    }     
}
