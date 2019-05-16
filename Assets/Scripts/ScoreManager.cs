using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text killText;
    int killCount = 0;
    private Slider healthSlider;
    int currentHealth;
    int startingHealth = 5;
    int numOfChances = 0;

   
    public static ScoreManager control; //refer to our script as control
    private void Awake()
    {
        if(control == null) // if control doesnt exist
        {
            control = this;
            DontDestroyOnLoad(gameObject); //dont desroy when the new scene is loaded
        }else if(control != this)
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        killText = GameObject.FindWithTag("Kill Count").GetComponent<UnityEngine.UI.Text>();
        healthSlider = GameObject.FindWithTag("HealthSlider").GetComponent<UnityEngine.UI.Slider>();
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
        Debug.Log("Starting Health is : " + currentHealth);
    }

    public void IncrementScore()
    {
        killCount++;
        //killText.text = "Kill Count : " + killCount.ToString();
    }

    public void DecrementHealth()
    {
        currentHealth--;
        healthSlider.value = currentHealth;
        Debug.Log("Current Health is : " + currentHealth);
        if(currentHealth <= 0){
            Debug.Log("The child has died");
        }
    }

    public void IncrementChances()
    {
        numOfChances++;
        Debug.Log("Number of Chances : " + numOfChances);
    }
    
    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.tag == "Enemy"){
    //         healthCount--;
    //         healthText.text = "Health : " + healthCount.ToString();
    //         if(healthCount == 0 ){
    //             healthText.text = "Your child did not make it.";
    //         }
    //     }
    // }


    public int returnHealth(){
        return currentHealth;
    }

    public int returnKillCount(){
        return killCount;
    }

    public int returnChances(){
        return numOfChances;
    }
}
