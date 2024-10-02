using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    float currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(5, 10f, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        currentAngle += speed * Time.deltaTime;

        float xScaled = Mathf.Cos(currentAngle);
        float yScaled = Mathf.Sin(currentAngle);
        
        float x = xScaled * radius;
        float y = yScaled * radius;

        transform.position = new Vector3(target.position.x + xScaled, target.position.y + yScaled);

    }

}
