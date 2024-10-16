using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject shieldPrefab;
    public string missileTag = "Missile";
    public Transform missileTransform;
    Vector3 playerDistance;
    Vector3 enemyToPlayer;
    private float acceleration = 0f;
    private float accelerationTime = 3f;
    private float targetSpeed = 2f;
    private float shieldLimit = 1;
    private float shieldUp = 0;
    private Vector3 velocity = Vector3.zero;


     void Start()
    {
    }
    private void Update()
    {

        GameObject missileOBJ = GameObject.FindWithTag(missileTag);
        if (missileOBJ != null)
        {
            missileTransform = missileOBJ.transform;
            Debug.Log("Rocket found");
        }

        acceleration = targetSpeed / accelerationTime;
        if (transform.position.x >= missileTransform.position.x - 2f && transform.position.y >= missileTransform.position.y - 2f && transform.position.x <= missileTransform.position.x + 2f && transform.position.y <= missileTransform.position.y + 2f)
        { 
            if (shieldUp < shieldLimit)
            {
                StartCoroutine(Shield());
                shieldUp++;
            }

            //      playerDirection();
        } else if (transform.position.x == playerTransform.position.x || transform.position.y == playerTransform.position.y) {
        
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

    IEnumerator Shield()
    {

        Vector3 direction = (missileTransform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(shieldPrefab, new Vector3(transform.position.x + direction.x, transform.position.y + direction.y), Quaternion.Euler(0f, 0f, angle));
        new WaitForSeconds(3f);

        var destroyMissile = GameObject.FindWithTag(missileTag);
        Destroy(destroyMissile);

        yield return shieldUp = 0;
    }

}
