using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitCount : MonoBehaviour
{
    private int playerHit = 0;

    public void IncrementHit()
    {
        playerHit++;
    }

    public int returnHitCount(){
        return playerHit;
    }


}
