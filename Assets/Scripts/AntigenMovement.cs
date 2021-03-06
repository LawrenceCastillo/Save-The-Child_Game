﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntigenMovement : MonoBehaviour
{
    public int speed = 2;
    Transform target;
    ScoreManager scoreManager;
    PlayerHitCount playerHitCount;

    Ray ray;
    RaycastHit hit;
    private AudioSource approach_antigen;
    float timer = 0;

    // private LineRenderer laserLine;
    // private float nextFire;
    // private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        playerHitCount = GameObject.FindWithTag("PlayerHit").GetComponent<PlayerHitCount>();
        approach_antigen = GameObject.FindGameObjectWithTag("Approach").GetComponent<AudioSource>();
    }

    
    // For PC Testing
    // void Update()
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    //     ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         //if user is looking at object
    //     if (Physics.Raycast(ray, out hit)){
    //         // if button is pressed and im looking at it -> destroy and increase score
    //         if (Input.anyKey){
    //             if(hit.collider.gameObject == gameObject){                
    //                 scoreManager.IncrementScore();
    //                 Destroy(gameObject);
    //                 //gameObject.GetComponent<Renderer>().material.color = new Color (255,255,0);
    //             } 
    //         }
    //         //else -> if looking at object make it purple
    //         else{
    //             if(hit.collider.gameObject==gameObject) {
    //                 gameObject.GetComponent<Renderer>().material.color = new Color (255,0,255);
    //             }
    //         }
    //     }
    //     // if im not looking at the object make it white
    //     else {
    //         gameObject.GetComponent<Renderer>().material.color = new Color (255,255,255);
    //     }
    
    // }


    // For Hololens Testing
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.75){
            approach_antigen.Play();
            timer = 0;
        }
        //  if (approach_antigen.isPlaying)
        //     {
        //         approach_antigen.Stop();
        //         approach_antigen.Play();
        //     }
        //     else
        //     {
        //         approach_antigen.Play();
        //     }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        RaycastHit hit;


        //if user is looking at object
        if (Physics.Raycast(headPosition, gazeDirection, out hit)){
            // if button is pressed and im looking at it -> destroy and increase score
            if (Input.anyKey){
                if(hit.collider.gameObject == gameObject){                
                    scoreManager.IncrementScore();
                    approach_antigen.Stop();
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
    }
         



    // if antigen collides with player -> destroy antigen + decrease health of player
    // void OnCollisionEnter(Collision other)
    void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag == "Player"){
            Debug.Log("Player Has Been Hit");
            scoreManager.DecrementHealth();
            playerHitCount.IncrementHit();
            Destroy(gameObject);
        }
    }

}
