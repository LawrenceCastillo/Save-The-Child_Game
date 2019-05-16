using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel1 : MonoBehaviour
{

     GameObject nextLevelButton;
     ScoreManager scoreManager;
     SpawnAntigens spawnAntigens;
     PlayerHitCount playerHitCount;

     public GameObject videoPlayer;
     private AudioSource player_win;
     private AudioSource player_lose;
     float timer;



    // Start is called before the first frame update
    void Start()
    {
        // SYNTAX --> myObject.GetComponent<MyScript>().MyFunction();
        nextLevelButton = GameObject.FindGameObjectWithTag("NextLevel");
        nextLevelButton.SetActive(false);
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        spawnAntigens = GameObject.FindWithTag("SpawnAntigen").GetComponent<SpawnAntigens>();
        playerHitCount = GameObject.FindWithTag("PlayerHit").GetComponent<PlayerHitCount>();
        videoPlayer.SetActive(false);
        player_win = GameObject.FindGameObjectWithTag("PlayerWin").GetComponent<AudioSource>();
        player_lose = GameObject.FindGameObjectWithTag("PlayerLose").GetComponent<AudioSource>();
    

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
            timer += Time.deltaTime;

            if (timer > 1){
                player_win.Play();
                timer = 0;
            }
            StartCoroutine(playVideo());
            nextLevelButton.SetActive(true);
            Debug.Log("SUCCESS! Continue To The Next Level");
        }

        if(scoreManager.returnHealth() <= 0 ){
            timer += Time.deltaTime;

            if (timer > 1){
                player_lose.Play();
                timer = 0;
            }
            Debug.Log(":( You Did Not Make It To The Next Level");
            DeathScene(); 
        }
    }

    public void DeathScene()
    {
        SceneManager.LoadScene("DoorMiniGame");
    }

    IEnumerator playVideo()
    {
        yield return new WaitForSeconds (0);
        videoPlayer.SetActive(true);
        yield return new WaitForSeconds (5);
        videoPlayer.SetActive(false);
        // load next level
    }




}
