using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public Vector3 arrivalPoint;

    float xCord;
    float yCord;

    // Start is called before the first frame update
    void Start()
    {
        AsteroidMovement();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x != xCord && transform.position.y != yCord)
        {
            transform.position += arrivalPoint * moveSpeed * Time.deltaTime;
        }



    }

    public void AsteroidMovement()
    {
        xCord = Random.Range(0, maxFloatDistance);
        yCord = Random.Range(0, maxFloatDistance);

        Debug.Log(xCord + " " + yCord);
        
        arrivalPoint = new Vector3(transform.position.x + xCord, transform.position.y + yCord);

    }

}
