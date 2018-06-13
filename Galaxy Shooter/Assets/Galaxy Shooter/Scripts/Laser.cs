using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    // Use this for initialization
    private float _speed = 10.0f;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // move up at 10 speed	
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // if laser is greater than 5.4f
        //  destroy the laser
        if (transform.position.y > 5.4f) 
            Destroy(this.gameObject);
          
         
	}
    
}
