using System.Collections;  // USING DIRECTIVES MUST BE AT THE TOP
using System.Collections.Generic;
using UnityEngine;

public class mid_fov : MonoBehaviour
{
    public float move_speed = 10.0f;  // MOVING UP 1 UNIT PER SECOND
    public float max_height = 10f; // OUT OF THE SCREEN

    void Start()
    {
        // NOTHING HERE
    }

    void Update()
    {
        transform.position += Vector3.up * move_speed * Time.deltaTime;  // LASER MOVES UPWARDS

        if (transform.position.y > max_height) // DESTROY THE LASER WHEN GOING OUT OF THE SCREEN
        {
            Destroy(gameObject); // DESTROY LASER
        }
    }
}
