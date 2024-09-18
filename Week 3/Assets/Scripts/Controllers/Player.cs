using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;


    private Vector3 velocity = Vector3.zero;
    private float acceleration = 0f;
    private float accelerationTime = 3f;
    private float targetSpeed = 2f;

    private void Start()
    {
    }
    void Update()
    {
        PlayerMovement();
        acceleration = targetSpeed / accelerationTime;

        Debug.Log(velocity);
    }


    public void PlayerMovement()
    {
        if (Input.GetKey("w") && velocity.y <= targetSpeed)
        {          
                velocity += Vector3.up * acceleration * Time.deltaTime;
        }
        
        if (Input.GetKey("a") && velocity.x >= -targetSpeed)
        {
            velocity += Vector3.left * acceleration * Time.deltaTime;
        }     
        
        if (Input.GetKey("s") && velocity.y >= -targetSpeed)
        {
            velocity += Vector3.down * acceleration * Time.deltaTime;
        }   
        
        if (Input.GetKey("d") && velocity.x <= targetSpeed)
        {
            velocity += Vector3.right * acceleration * Time.deltaTime;
        }        
        
        transform.position += velocity.normalized * Time.deltaTime;


    }
}
