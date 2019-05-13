using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

     GameObject nextLevelButton;
     ScoreManager scoreManager;
     SpawnAntigens spawnAntigens;
     PlayerHitCount playerHitCount;


    // Start is called before the first frame update
    void Start()
    {
        // SYNTAX --> myObject.GetComponent<MyScript>().MyFunction();
        nextLevelButton = GameObject.FindGameObjectWithTag("NextLevel");
        nextLevelButton.SetActive(false);
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        spawnAntigens = GameObject.FindWithTag("SpawnAntigen").GetComponent<SpawnAntigens>();
        playerHitCount = GameObject.FindWithTag("PlayerHit").GetComponent<PlayerHitCount>();


        // // returns current health
        // Debug.Log("ScoreM Health is " + scoreManager.returnHealth());
        // // returns numOfAntigens 
        // Debug.Log("ScoreM Antigens is " + spawnAntigens.returnNumOfAntigens());
        // //returns killCount
        // Debug.Log("ScoreM KillC is " + scoreManager.returnKillCount());

    }

    // Update is called once per frame
    void Update()
    {
        if(scoreManager.returnHealth() > 0 && ( scoreManager.returnKillCount() + playerHitCount.returnHitCount() == spawnAntigens.returnNumOfAntigens()) ){
            nextLevelButton.SetActive(true);
            Debug.Log("SUCCESS! Continue To The Next Level");
        }

        if(scoreManager.returnHealth() <= 0 ){
            Debug.Log(":( You Did Not Make It To The Next Level");
            DeathScene(); 
        }
    }

    public void DeathScene()
    {
        SceneManager.LoadScene("DoorMiniGame");
    }




}
