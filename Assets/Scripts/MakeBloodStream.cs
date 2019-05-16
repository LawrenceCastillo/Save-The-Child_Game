using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBloodStream : MonoBehaviour{
    public GameObject platform_prefab;
    float timer = 0;

    void Update (){
		timer += Time.deltaTime;

        if (timer > .06){
            GameObject p;
            p = Instantiate(platform_prefab, 
                            new Vector3(-20f, Random.Range(0,5),Random.Range(0,5)), 
                            Quaternion.identity);
            p.GetComponent<Renderer>().material.color = Color.HSVToRGB(1f,1f,.6f);
            p.transform.Rotate(Random.Range(0,90),Random.Range(0,90),Random.Range(0,90));
            timer = 0;
        }
	}
}
