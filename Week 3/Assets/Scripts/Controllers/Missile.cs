using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform enemyShip;
    public string targetTag = "Enemy";
    private float speed = 1f;
    void Start()
    {
        GameObject enemyOBJ = GameObject.Find(targetTag);
        enemyShip = enemyOBJ.transform;




    }

    // Update is called once per frame
    void Update()
    {
        Launch();
    }
    
    private void Launch()
    {
        if (enemyShip != null)
        {
            Vector3 direction = (enemyShip.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            transform.position += direction * speed * Time.deltaTime;
        }


    }
}
