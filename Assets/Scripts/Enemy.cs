using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // variables
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    private float xLimit = 23;
    private float yLimit = 10;
    private float zLimit = 25;

    // Start is called before the first frame update
    void Start()
    {
        // get enemy Rigidbody and Player object
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // calculate distance between enemy and player, normalize the distance, and have the enemy start moving towards the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -yLimit || transform.position.z > zLimit || transform.position.z < -zLimit || transform.position.x > xLimit || transform.position.x < -xLimit)
        {
            Destroy(gameObject);
        }
    }
}
