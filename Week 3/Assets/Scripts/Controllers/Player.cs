using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    private void Start()
    {

        SpawnPowerups(4,5);

    }
    void Update()
    {
        PlayerMovement();
        acceleration = targetSpeed / accelerationTime;
        EnemyRadar(2, 8);

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

        for (int currentPoint = 0; currentPoint < circlePoints; currentPoint++)
        {

            float circumference = (float)currentPoint / circlePoints;
            float radian = circumference * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(radian);
            float yScaled = Mathf.Sin(radian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 endPoint = new Vector3 (transform.position.x + x, transform.position.y + y);
            Vector3 currentPosition = new Vector3 (endPoint.x, endPoint.y);

            float circumference2 = (float)currentPoint+1 / circlePoints;
            float radian2 = circumference2 * 2 * Mathf.PI;

            float xScaled2 = Mathf.Cos(radian2);
            float yScaled2 = Mathf.Sin(radian2);

            float x2 = xScaled2 * radius;
            float y2 = yScaled2 * radius;


            Vector3 nextEndpoint = new Vector3(transform.position.x + x2, transform.position.y + y2);

            // Debug.Log(radius);
            // Debug.Log(currentPosition + " " + nextEndpoint);
            // Debug.Log(currentPoint);
            // Debug.Log(nextEndpoint);


            Debug.DrawLine(currentPosition, nextEndpoint);
        }

    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {

            float angle = 360f / numberOfPowerups;

        for (int currentNumberOfPowerups = 0; currentNumberOfPowerups < numberOfPowerups; currentNumberOfPowerups++)
        {

            float spawnPointAngle = currentNumberOfPowerups * angle;
            float radianPowerUp = spawnPointAngle * Mathf.Deg2Rad;

            float xPowerUp = Mathf.Cos(radianPowerUp);
            float yPowerUp = Mathf.Sin(radianPowerUp);

            float xScaledPowerUps = xPowerUp * radius;
            float yScaledPowerUps = yPowerUp * radius;

            Vector3 spawnPoint = new Vector3(transform.position.x + xScaledPowerUps, transform.position.y + yScaledPowerUps);

            Instantiate(bombPrefab, spawnPoint, Quaternion.identity);
            Debug.Log(currentNumberOfPowerups);
        }
        
    }


}
