using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 4.5f;
    private Rigidbody2D rb2d;
    public bool isComputer = false;
    GameObject theBall;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    void IsComputer(bool is_computer)
    {
        isComputer = is_computer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isComputer)
        {
            var pos = transform.position;
            pos.y = theBall.transform.position.y;
            transform.position = pos;
        }
        else
        {
            var vel = rb2d.velocity;
            if (Input.GetKey(moveUp))
            {
                vel.y = speed;
            }
            else if (Input.GetKey(moveDown))
            {
                vel.y = -speed;
            }
            else
            {
                vel.y = 0;
            }
            rb2d.velocity = vel;

            var pos = transform.position;
            if (pos.y > boundY)
            {
                pos.y = boundY;
            }
            else if (pos.y < -boundY)
            {
                pos.y = -boundY;
            }
            transform.position = pos;
        }
    }
}
