using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    float gravity = 14;
    public float Jump = 10;
    float verticalVelocity;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime * Time.deltaTime;
            if (Input.GetAxis("Jump") > 0)
            {
                verticalVelocity = Jump;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime * Time.deltaTime;
        }

        float runspeed = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            runspeed = 2f;
        }
        else
        {
            runspeed = 1;
        }
        float x = Input.GetAxis("Horizontal");
        float z1 = Input.GetAxis("Vertical");

        if (Mathf.Abs(x) + Mathf.Abs(z1) > 0)
            anim.SetFloat("speed", 1);
        else
            anim.SetFloat("speed", 0);

        //Vector3 moveDierction = new Vector3(x, 0, z1).normalized;
        //if(moveDierction.magnitude> 0.1f)
        //{
        //    float agnle = Mathf.Atan2(moveDierction.x, moveDierction.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        //    transform.rotation=Quaternion.Euler(0, agnle, 0);//?????!!!!
        //}
        //moveDierction = Camera.main.transform.TransformDirection(new Vector3(moveDierction.x,0,moveDierction.z));
        Vector3 moveDierction = new Vector3(x*speed*runspeed, verticalVelocity, z1*speed*runspeed);
        controller.Move(moveDierction);
        //controller.Move(new Vector3(moveDierction.x*speed*runspeed,verticalVelocity,moveDierction.z*speed*runspeed)*Time.deltaTime);
    }
}
