using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoLoad : MonoBehaviour {
    public GameObject videoPlayer;

    private void Start(){
        videoPlayer.SetActive(false);
    }

    void Update(){
        if (1)      // Player Wins then play video
            StartCoroutine(playVideo());

        else if (0){// Player loses 
            // load "doors" screen
        }
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
