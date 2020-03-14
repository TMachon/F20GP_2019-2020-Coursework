using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    GameObject robot;

    void Start()
    {
        Debug.Log("WALL READY");
        robot = GameObject.Find("robotSphere");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("WALL HIT");
        if (collision.collider.gameObject.tag == "Player")
        {
            robot.GetComponent<RobotFreeAnim>().Stop();
        }
    }
}
