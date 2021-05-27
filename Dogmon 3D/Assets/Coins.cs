using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Coins : MonoBehaviour
{
    public PlayerMovement player;  
    public GameObject kosc; 
    float speed = 70.0f; //prędkość obrotu kostki 
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
        //W trakcie kolizji, algorytm sam wylicza ile jest i ile powinno być punktów, nie trzeba zmieniać

    
    void Start(){
        player = FindObjectOfType<PlayerMovement> (); //automatycznie przypisz obiekt        
        lvlNumber = SceneManager.GetActiveScene().buildIndex;
    }

    void Update(){
        kosc.transform.Rotate(Vector3.up * speed * Time.deltaTime);        
    }

    void OnTriggerEnter(Collider col){ //jesli wejdzie na pole    
        //if(col.name== "Player"){ //jesli colider to player i teleport jest true           
        //   Destroy(gameObject);             
        //}


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

            if (col.gameObject.tag == "Coins")
            {
                //powiększ coin o 1
                coin++;
                //zmien wczesniej wybrany TextMeshPro na Tekst + ilość punktów zamienionych na string
                if(coin==coinLVL){ //jeśli osiągniemy ilość punktów do przejścia na kolejny poziom to odblokuj teleport /teleportuj bohatera/
                    teleport = true;
                    //gameObject.transform.position= new Vector3(28,2,0);
                }
                textCoins.text = coin.ToString() + " / " + coinLVL;
                
                    //tworzymy Vector3 z miejscem kolizji
                Vector3 colPosition = col.transform.position;
                    //Odtwórz dźwięk coinSound w miejscu kolizji
                AudioSource.PlayClipAtPoint(coinSound, colPosition, volume);
                    //Zniszcz obiekt
                Destroy(gameObject);
            }
    }   

    
}
