using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float teerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float bumbSpeed = 15f;
    
 
    void Update()
    {
        
        float teerAmount = Input.GetAxis("Horizontal") * teerSpeed* Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") *moveSpeed* Time.deltaTime;
        transform.Rotate(0, 0, -teerAmount);
        transform.Translate(0, speedAmount, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = bumbSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }


}
