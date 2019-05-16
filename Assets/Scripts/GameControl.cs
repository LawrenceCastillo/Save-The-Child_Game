using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour{
    public  GameObject[] doors;
    private int          door_winner;
    int                  chances;
    Ray                  ray;
    ScoreManager         scoreManager;
    public Text          numChancesText;
    public Text          winLoseText;

    private void Start(){
        door_winner = Random.Range(0, 5);
        Debug.Log ("Winner Index is: " + door_winner);
        
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        chances = scoreManager.returnChances();
        numChancesText.text  =  "Remaining Chances : " + chances.ToString();
        Debug.Log ("Chances from script: " + scoreManager.returnChances());
    }

    // private void Update()
    // {
    //     //chances = scoreManager.returnChances();
    //     //numChancesText.text  =  "Remaining Chances : " + scoreManager.returnChances();
    //     //Debug.Log ("Chances remaining: " + scoreManager.returnChances());

        

    //     ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
         
    //     if (chances > 0 && 
    //        Physics.Raycast (ray, out hit) && 
    //        Input.GetMouseButtonDown(0))
    //     {
    //         if(hit.transform.tag == "Door")
    //         {
    //             //Debug.Log ("This is a Door");
    //             //Debug.Log( "Object: " + hit.transform.gameObject.name );
    //             if (doors[door_winner].gameObject == hit.transform.gameObject){
    //                 Debug.Log ("Winner");
    //                 winLoseText.text = "Winner";
    //             }

    //             else if (hit.transform.gameObject.name != "checked"){
    //                 hit.transform.gameObject.name = "checked";
    //                 Debug.Log ("Not a winner");
    //                 winLoseText.text = "Not A Winner";
    //                 chances--;
    //                 Debug.Log ("Chances remaining: " + chances);
    //                 numChancesText.text  =  "Remaining Chances : " + chances.ToString();
    //             }
    //         }
    //     }
    //     else if (chances == 0) {
    //         Debug.Log ("You Lost!");
    //         //winLoseText.text = "You Lost!";
    //     }
    // }

    // MODIFIED VERSION -> includes color indicator for doors + scene transition
     private void Update()
    {
    
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if(chances > 0 && Physics.Raycast (ray, out hit)){
            if(Input.GetMouseButtonDown(0)){
                if(hit.collider.tag=="Door") {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color (255,0,255);
                    if (doors[door_winner].gameObject == hit.transform.gameObject){
                        Debug.Log ("Winner");
                        WinScene();
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
            
            else {
                 hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color (255,0,255);
               }
        }
        else if (chances == 0) {
           LoseScene();
        }
        
        else {
            for(int i = 0; i < doors.Length; i++){
             doors[i].GetComponent<Renderer>().material.color = new Color (255,255,255);
            }
        }
    }

// FOR HOLOLENS
    // private void Update()
    // {
    
    //     var headPosition = Camera.main.transform.position;
    //     var gazeDirection = Camera.main.transform.forward;
    //     RaycastHit hit;

    //     if(chances > 0 && Physics.Raycast (headPosition, gazeDirection, out hit)){
    //         if(Input.anyKey){
    //             if(hit.collider.tag=="Door") {
    //             hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color (255,0,255);
    //                 if (doors[door_winner].gameObject == hit.transform.gameObject){
    //                     Debug.Log ("Winner");
    //                     WinScene();
    //                     winLoseText.text = "Winner";
    //                 }
    //               else if (hit.transform.gameObject.name != "checked"){
    //                 hit.transform.gameObject.name = "checked";
    //                 Debug.Log ("Not a winner");
    //                 winLoseText.text = "Not A Winner";
    //                 chances--;
    //                 Debug.Log ("Chances remaining: " + chances);
    //                 numChancesText.text  =  "Remaining Chances : " + chances.ToString();
    //                 }
    //             }
    //         } 
            
    //         else {
    //              hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color (255,0,255);
    //            }
    //     }
    //     else if (chances == 0) {
    //        LoseScene();
    //     }
        
    //     else {
    //         for(int i = 0; i < doors.Length; i++){
    //          doors[i].GetComponent<Renderer>().material.color = new Color (255,255,255);
    //         }
    //     }
    // }

    public void WinScene()
    {
        SceneManager.LoadScene("EndingWin");
    }

    public void LoseScene()
    {
        SceneManager.LoadScene("EndingLose");
    }


}
