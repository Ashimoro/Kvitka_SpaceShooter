using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position = transform.up;
        Debug.DrawLine(startPos, endPos, Color.red);

        transform.Rotate(0,0 360*Time.deltaTime);

    }
}
