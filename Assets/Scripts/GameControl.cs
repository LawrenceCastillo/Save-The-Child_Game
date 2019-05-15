using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour{
    public  GameObject[] doors;
    private int          door_winner;
    private int          chances;
    Ray                  ray;
    ScoreManager         scoreManager;
    public Text          numChancesText;
    public Text          winLoseText;

    private void Start(){
        door_winner = Random.Range(0, 5);
        Debug.Log ("Winner Index is: " + door_winner);
        //chances = 3;
        // Debug.Log ("Chances remaining: " + chances);
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        chances = scoreManager.returnChances();
        numChancesText.text  =  "Remaining Chances : " + chances.ToString();
        Debug.Log ("Chances remaining: " + scoreManager.returnChances());

        //chances = 3;
        //Debug.Log ("Chances remaining: " + chances);
        


    }

    private void Update()
    {
        //chances = scoreManager.returnChances();
        

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
         
        if (chances > 0 && 
           Physics.Raycast (ray, out hit) && 
           Input.GetMouseButtonDown(0))
        {
            if(hit.transform.tag == "Door")
            {
                //Debug.Log ("This is a Door");
                //Debug.Log( "Object: " + hit.transform.gameObject.name );
                if (doors[door_winner].gameObject == hit.transform.gameObject){
                    Debug.Log ("Winner");
                    winLoseText.text = "Winner";
                }

                else if (hit.transform.gameObject.name != "checked"){
                    hit.transform.gameObject.name = "checked";
                    Debug.Log ("Not a winner");
                    winLoseText.text = "Not A Winner";
                    chances--;
                    Debug.Log ("Chances remaining: " + chances);
                    numChancesText.text  =  "Remaining Chances : " + chances.ToString();
                }
            }
        }
        else if (0 == chances) {
            Debug.Log ("You Lost!");
            winLoseText.text = "You Lost!";
        }
    }
}
