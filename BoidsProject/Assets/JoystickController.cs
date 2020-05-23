using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Joystick joystick;

    public float currentSpeed;
    public float maxSpeed;
    public float normalSpeed;
    public float rotateSpeed;
    public Vector3 velocity;


    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rotateSpeed = 2.0f;
        normalSpeed = 2f;
        maxSpeed = normalSpeed * 10;
        currentSpeed = normalSpeed;
        velocity = new Vector3(-1,0,0);//this.transform.forward;
    }

    // Update is called once per frame
    void Update()
    { 
        float xRot = rotateSpeed * joystick.Horizontal;
        float yRot = rotateSpeed * joystick.Vertical;

        transform.Rotate(-yRot, xRot, 0.0f);
        //velocity += new Vector3(0.0f, yRot, xRot);
        /*
                 this.transform.position += Time.deltaTime * velocity;
        this.transform.rotation = Quaternion.LookRotation(velocity);
         */
        //this.transform.rotation = Quaternion.LookRotation(velocity);
        this.transform.position += this.transform.forward * currentSpeed * Time.deltaTime;

        if (currentSpeed > normalSpeed)
        {
            currentSpeed -= 0.05f;
        }

    }

    public void sprint()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
    }
}
