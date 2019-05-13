using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAntigens : MonoBehaviour
{
    public GameObject antigenPrefab;
    public int numOfAntigens;
    public GameObject player;
    GameObject spawnButton;
    ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 0; i < numOfAntigens; i++)
        // {
        //     Instantiate(antigenPrefab, new Vector3(player.transform.position.x + spawnLoc(), player.transform.position.y, player.transform.position.z + spawnLoc()), Quaternion.identity);
        // }
        spawnButton = GameObject.FindGameObjectWithTag("Button");
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();

    }

    // spawn over a range
    public void Instantiate(){
        scoreManager.IncrementChances();
        for (int i = 0; i < numOfAntigens; i++){
            Invoke("SpawnEnemy", Random.Range(1,7));
        }
    }

    public int returnNumOfAntigens(){
        return numOfAntigens;
    }

    // instantiate enemies
    void SpawnEnemy(){
        spawnButton.SetActive(false);
        Instantiate(antigenPrefab, new Vector3(player.transform.position.x + spawnLoc(), player.transform.position.y, player.transform.position.z + spawnLoc()), Quaternion.identity);
    }

    // for level 0
    public void DestroyButton(){
        spawnButton.SetActive(false);
    }

    // spawn emeny at random points
    float spawnLoc(){
        float num = Random.Range(1,10);
        if(num % 2 == 0){
            float positiveNum = Random.Range(10.0f, 50.0f);
            return positiveNum;
        }
        else{
            float negativeNum = Random.Range(-10.0f, -50.0f);
            return negativeNum;
        }
    }

    
}
