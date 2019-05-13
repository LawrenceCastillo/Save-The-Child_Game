using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeAntigens : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    
    // For PC Testing
    // void Update()
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    //     ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         

    //     //if (Input.GetMouseButtonDown(0)) 
    //     if (Input.anyKey)
    //     {
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hit;
            
    //         if(Physics.Raycast(ray,out hit))
    //         {
    //             if(hit.collider.gameObject==gameObject){                
    //                 Debug.Log("Laser Shoot");
    //                 scoreManager.IncrementScore();
    //                 Destroy(gameObject);
    //             } 
    //         }
    //     }
    //     else if(Physics.Raycast(ray, out hit))
    //         {
    //             if(hit.collider.gameObject==gameObject) {
    //                 gameObject.GetComponent<Renderer>().material.color = new Color (255,0,255);
    //                 Debug.Log("Hovering Antigen");
    //             }
    //         }
    //         else{
    //             gameObject.GetComponent<Renderer>().material.color = new Color (255,255,255);
    //         }
    // }


    // For Hololens Testing
    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        RaycastHit hit;


        //if user is looking at object
        if (Physics.Raycast(headPosition, gazeDirection, out hit)){
            // if button is pressed and im looking at it -> destroy and increase score
            if (Input.anyKey){
                if(hit.collider.gameObject == gameObject){                
                    Destroy(gameObject);
                    //gameObject.GetComponent<Renderer>().material.color = new Color (255,255,0);
                } 
            }
            //else -> if looking at object make it purple
            else{
                if(hit.collider.gameObject==gameObject) {
                    gameObject.GetComponent<Renderer>().material.color = new Color (255,0,255);
                }
        }
        }
        // if im not looking at the object make it white
        else {
            gameObject.GetComponent<Renderer>().material.color = new Color (255,255,255);
        }
         

        //if (Input.GetMouseButtonDown(0)) 
        // if (Input.anyKey)
        // {
        //     //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(headPosition, gazeDirection, out hit))
        //     {
        //         if(hit.collider.gameObject == gameObject){                
        //             scoreManager.IncrementScore();
        //             Destroy(gameObject);
        //         } 
        //     }
        // }
        
        // else if (Physics.Raycast(headPosition, gazeDirection, out hit))
        //     {
        //         if(hit.collider.gameObject==gameObject) {
        //             gameObject.GetComponent<Renderer>().material.color = new Color (255,0,255);
        //         }
        //     else{
        //         gameObject.GetComponent<Renderer>().material.color = new Color (255,255,255);
        //     }
        // }
        }

}
