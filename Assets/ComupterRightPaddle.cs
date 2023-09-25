using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComupterRightPaddle : MonoBehaviour
{
    GameObject theBall;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.y = theBall.transform.position.y;
        transform.position = pos;
    }
}
