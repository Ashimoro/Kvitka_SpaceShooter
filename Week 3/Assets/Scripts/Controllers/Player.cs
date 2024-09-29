using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    public float radius = 1f;
    public int circlePoints = 8;

    int currentPoints = 0;

    private void Start()
    {
    }
    void Update()
    {
        PlayerMovement();
        acceleration = targetSpeed / accelerationTime;
        EnemyRadar(radius, circlePoints);


      //  Debug.Log(velocity);
    }   


    public void PlayerMovement()
    {
        if (Input.GetKey("w") && velocity.y <= targetSpeed)
        {          
                velocity += Vector3.up * acceleration * Time.deltaTime;
        }
        
        else if (Input.GetKey("a") && velocity.x >= -targetSpeed)
        {
            velocity += Vector3.left * acceleration * Time.deltaTime;
        }     
        
        else if (Input.GetKey("s") && velocity.y >= -targetSpeed)
        {
            velocity += Vector3.down * acceleration * Time.deltaTime;
        }

        else if (Input.GetKey("d") && velocity.x <= targetSpeed)
        {
            velocity += Vector3.right * acceleration * Time.deltaTime;
        } 
        
        else if (!Input.GetKey("a") && !Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("d"))
        {
            velocity -= velocity * Time.deltaTime;
        }
        transform.position += velocity * Time.deltaTime;



    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        Vector3[] points = new Vector3[circlePoints];
        points[0] = new Vector3 (transform.position.x, transform.position.y + radius);
        points[1] = new Vector3 (transform.position.x + radius, transform.position.y + radius);
        points[2] = new Vector3 (transform.position.x + radius, transform.position.y);
        points[3] = new Vector3 (transform.position.x + radius, transform.position.y - radius);
        points[4] = new Vector3 (transform.position.x, transform.position.y - radius);
        points[5] = new Vector3 (transform.position.x - radius, transform.position.y - radius);
        points[6] = new Vector3 (transform.position.x - radius, transform.position.y);
        points[7] = new Vector3 (transform.position.x - radius, transform.position.y + radius);

        foreach (var point in points)
        {
            Debug.DrawLine(transform.position, point);
        }




    }


}
