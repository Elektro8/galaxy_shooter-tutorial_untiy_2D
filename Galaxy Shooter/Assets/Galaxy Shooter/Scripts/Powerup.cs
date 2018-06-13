using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int PowerupID; // 0 = triple shot   1= speed boost, 2 = shields
	
	
	// Update is called once per frame
	void Update ()
    {

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);
        //acess the player
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {   //enable triple shot
                //if powerup id is 0 enable tripleshot
                if (PowerupID == 0) 
                {
                    player.TripleShotPowerupOn();
                }
                else if (PowerupID == 1)
                {
                    player.SpeedBoostPowerupOn();
                }
                else if(PowerupID == 2)
                {
                    //enable shields
                }
                

                
            }

           
            Destroy(this.gameObject);
            //turn the triple sho tbool to true
            //dstroy our sleves

            //handle to the component
        }


    }

   

}

