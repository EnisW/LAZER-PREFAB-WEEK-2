using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mid_lazer_script : MonoBehaviour
{
    public GameObject laser_pre_fab;          // LASER PREFAB
    public Transform laser_spawn_point;       // LASER SPAWN POINT
    public float laser_shoot_speed = 1f;      // LASER SPEED
    public float fire_rate = 0.5f;            // TIME BETWEEN SHOTS
    private float next_fire_time = 0f;        // NEXT FIRE TIME
    private int count = 0;                    // TOTAL SHOT COUNT


    void Start()
    {
        // NOTHING HERE
    }


    void Update()
    {
        
        if (Time.time > next_fire_time && Input.GetKeyDown(KeyCode.Space)) // IF WE CAN FIRE AND THE SPACE KEY IS PRESSED
        {
            shoot_lazer(); // SHOOT LASER
            next_fire_time = Time.time + fire_rate; // SET NEXT FIRE TIME
        }
    }


    void shoot_lazer()  // LASER SHOOTING FUNCTION
    {
        count++; // INCREMENT SHOT COUNT

        // IF SHOT COUNT IS A MULTIPLE OF 3
        if (count % 3 == 0) 
        {
            // CREATE THREE LASER PREFABS AT THE SPAWN POINT
            for (int i = -1; i <= 1; i++) // VALUES -1 FOR LEFT, 0 FOR CENTER, 1 FOR RIGHT LASER
            { 
                GameObject laser = Instantiate(laser_pre_fab, laser_spawn_point.position, Quaternion.identity); // CREATE LASER
                mid_fov laserMovement = laser.AddComponent<mid_fov>(); // ADD MOVEMENT SCRIPT TO LASER
                laserMovement.move_speed = laser_shoot_speed; // SET LASER SPEED
                laser.transform.position += new Vector3(i, 0, 0); // SHIFT LASER POSITION LATERALLY
            }
        }
        else
        {
            // CREATE A NORMAL LASER
            GameObject laser = Instantiate(laser_pre_fab, laser_spawn_point.position, Quaternion.identity); // CREATE LASER
            mid_fov laserMovement = laser.AddComponent<mid_fov>(); // ADD MOVEMENT SCRIPT TO LASER
            laserMovement.move_speed = laser_shoot_speed; // SET LASER SPEED
        }
    }
}
