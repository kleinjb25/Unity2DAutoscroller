using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    private float jumpThrust;
    [SerializeField] private GameObject followCam = null;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        speed = 200.0f;
        jumpThrust = 6.0f;
        isGrounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForceY(jumpThrust, ForceMode2D.Impulse);
            isGrounded = false;
            Debug.Log("jump");
        }
        if (!isGrounded)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, -90f)), Time.deltaTime * 1f);
        }
        

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocityX = speed * Time.deltaTime;
        followCam.transform.position = transform.position + new Vector3(2.78f, 1.85f, -10);
    }

    void OnCollisionStay2D()
    {
        if (!isGrounded)
        {
            GetComponent<Rigidbody2D>().SetRotation(0f);
        }
        
        if (GetComponent<Rigidbody2D>().velocityY == 0)
        {
            isGrounded = true;
        }
    }
}
