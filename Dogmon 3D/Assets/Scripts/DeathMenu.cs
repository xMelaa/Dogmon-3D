using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject deathMenuUI;
    public float energia = 1;

    // Update is called once per frame
    void Update()
    {
        if (energia < 1)
        {
            //DeathMenu.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0); //scena 0 = menu
    }

    public void ResetLevel(){
        SceneManager.LoadScene(1); //scena 0 = menu
    }

}
