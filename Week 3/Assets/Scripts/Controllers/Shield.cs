using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public Transform missileTransform;
    public string targetTag = "Missile";


    // Start is called before the first frame update
    void Start()
    {
        GameObject missileOBJ = GameObject.FindWithTag(targetTag);
        missileTransform = missileOBJ.transform;
    }

    // Update is called once per frame
    void Update()
    {
        shield();
    }

    public void shield()
    {
        Vector3 direction = (missileTransform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);


    }

}
