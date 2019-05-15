using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    
    // public static DontDestroy  instance = null; 
    
    // void Awake() { 
    //     if (instance == null) 
    //         instance = this; 
    //     else {
    //         Destroy (gameObject); 
    //     }
    //         DontDestroyOnLoad (gameObject); 
    // }

     void Awake ()
 {
 DontDestroyOnLoad(this.gameObject);
 }
        
}
