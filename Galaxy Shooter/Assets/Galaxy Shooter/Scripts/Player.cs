using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // publice or private identifier
    //data type (int, floats, bool, strings )
    //every variable has a NAME
    //optional value assigned
    
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleshotprefab;
    [SerializeField]




    //fireRate is  0.25f
    //canFire -- has the amount of time between firing passed?
    //Time.time
    //variable if i have collected speed powerup
    public bool canSpeedBoost = false;
    public bool canTripleshot = false; 
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;
    
    private void Start()
    {
        //current pos = new position
        //transform.position = new Vector3(0, 0, 0);
    }
    private void Update()
    {

        Movement();
        // if space key pressed
        // spawn laser at player position
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {

            Shoot();
          



       
          
        }
    }

    /*private void Tripleshot()
    {
        if (Time.time > _canFire)
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0.53f, -0.019f, 0), Quaternion.identity);          
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.84f, 0), Quaternion.identity);           
            Instantiate(_laserPrefab, transform.position + new Vector3(-0.53f, -0.019f, 0), Quaternion.identity);
            _canFire = Time.time + _fireRate;
        }
    }  */
    private void Shoot()
    {
        // if triple shot
        //shoot 3 laser
        // else shoot 1

        

        if (Time.time > _canFire)
        
        {
            if (canTripleshot == true)
            {
                 /*Instantiate(_laserPrefab, transform.position + new Vector3(0.53f, -0.019f, 0), Quaternion.identity);
                 Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.84f, 0), Quaternion.identity);
                 Instantiate(_laserPrefab, transform.position + new Vector3(-0.53f, -0.019f, 0), Quaternion.identity);*/
                 Instantiate(_tripleshotprefab, transform.position, Quaternion.identity);
            }

            else 
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.84f, 0), Quaternion.identity);
            }
            
            _canFire = Time.time + _fireRate;
        }
    }

    private void Movement()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //if speed boost enabled
        // move 1.5x the normal speed
        //else
        // move normal speed
        if(canSpeedBoost == true)
        {
            _speed = 7.5f;
        }
        else
        {
            _speed = 5.0f;
        }


        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);



        //if player on the y is greater than 0
        //set player position to 0 only on Y axis
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        if (transform.position.x > 9.2f)
        {
            transform.position = new Vector3(-8.81f, transform.position.y, 0);
            //Destroy(this.gameObject);
        }
        else if (transform.position.x < -9.12f)
        {
            transform.position = new Vector3(8.82f, transform.position.y, 0);
            //Destroy(this.gameObject);
        }


     }
    public void TripleShotPowerupOn()
    {
        canTripleshot = true;
        StartCoroutine(TripleShotPowerDown());
        
    }
    //method to enable powerup

    public void SpeedBoostPowerupOn()
    {
        canSpeedBoost = true;
        StartCoroutine(SpeedboostPowerdown());

    }

        // coroutine method (ienumerator) to powerdown the speed boost
      public IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleshot = false;
    }

    public IEnumerator SpeedboostPowerdown()
    {
        yield return new WaitForSeconds(10);
        canSpeedBoost = false;
    }
}
