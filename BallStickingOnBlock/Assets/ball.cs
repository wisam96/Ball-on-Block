using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public Rigidbody2D Ball;
    Vector3 dir;

    private float speed = 500f;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Ball.velocity.y == 0 && Ball.velocity.x == 0)
        {


            Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            Vector3 mouse_pos = Input.mousePosition;
            Vector3 ball_pos = Camera.main.WorldToScreenPoint(Ball.transform.position);

            mouse_pos.x = mouse_pos.x - ball_pos.x;
            mouse_pos.y = mouse_pos.y - ball_pos.y;

            float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 270;
            Ball.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            dir = mouse_pos;

        }
        if (Input.GetMouseButtonUp(0) && Mathf.Abs(Ball.velocity.y) == 0 && Mathf.Abs(Ball.velocity.x) == 0)
        {

            dir.Normalize();
            Ball.AddForce(dir * speed);


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sticky")
        {
            Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }


    }
}
