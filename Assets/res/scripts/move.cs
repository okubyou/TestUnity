using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    Rigidbody rb;

    float speed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(0, 5, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        }
        if (Input.GetKey(KeyCode.S)) //両方押しちゃっうようなときは、後退優先
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }

    }

}
