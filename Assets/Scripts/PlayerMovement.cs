using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private Vector3 velo;
    public float jump_speed;
    public GameObject player;

    void jump()
    {
        Vector3 big_jump = new Vector3(0.0f, jump_speed, 0.0f);
        rb.AddForce(big_jump, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = player.transform.forward * moveVertical;
        Vector3 right = player.transform.right * moveHorizontal;

        Vector3 normalize = (forward + right).normalized;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(normalize * speed * Time.deltaTime);

        velo = rb.velocity;

        velo = Vector3.ClampMagnitude(velo, speed);

        rb.velocity = velo;
        print(rb.velocity.magnitude);

        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }



    }
}
