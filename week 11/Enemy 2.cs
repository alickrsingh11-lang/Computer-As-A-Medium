using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float speed = 4f;
    private float frequency = 4f; // How fast it weaves left and right
    private float magnitude = 1.5f; // How wide the wave is

    private Vector3 startPos;

    void Start()
    {
        // Save the starting position
        startPos = transform.position;
    }

    void Update()
    {
        // Move the base position downward over time
        startPos -= new Vector3(0, 1, 0) * Time.deltaTime * speed;

        // Apply a left-to-right zigzag wave behavior onto the falling position
        transform.position = startPos + new Vector3(Mathf.Sin(Time.time * frequency) * magnitude, 0, 0);

        // Clean up the enemy when it leaves the bottom of the screen
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
