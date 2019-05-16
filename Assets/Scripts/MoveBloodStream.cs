using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBloodStream : MonoBehaviour{
    public float speed;
    float x;
    float y;
    float z;

	// Use this for initialization
	void Start (){
		speed = Random.Range(6,7);
        x = Input.GetAxis("Vertical");
	}
	
	// Update is called once per frame
	void Update (){
	    transform.localPosition = new Vector3(transform.localPosition.x + 
                                                        speed * Time.deltaTime, 
                                              transform.localPosition.y,
                                              transform.localPosition.z);
        transform.Rotate(x+.3f, y+.3f, z+.3f, Space.Self);
        if (transform.localPosition.x > 20){
            Destroy(this.gameObject);
        }
	}
}
