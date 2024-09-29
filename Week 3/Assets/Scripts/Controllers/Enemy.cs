using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 playerDistance;
    Vector3 enemyToPlayer;
    private float acceleration = 0f;
    private float accelerationTime = 3f;
    private float targetSpeed = 2f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        acceleration = targetSpeed / accelerationTime;
        if (transform.position.x != playerTransform.position.x || transform.position.y != playerTransform.position.y)
        { 
            playerDirection();
        } else if (transform.position.x == playerTransform.position.x || transform.position.y == playerTransform.position.y)
        {
            velocity = Vector3.zero;
        }


    }

    public void playerDirection()
    {

        if (velocity.y >= -targetSpeed && velocity.x >= -targetSpeed && velocity.y <= targetSpeed && velocity.x <= targetSpeed)
        {
        velocity += transform.position * acceleration * Time.deltaTime;
        }

        transform.position += playerTransform.position - transform.position + velocity * Time.deltaTime;
       // Debug.Log(velocity);
    }


}
