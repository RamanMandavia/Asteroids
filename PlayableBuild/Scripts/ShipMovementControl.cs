using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementControl : MonoBehaviour
{
    public float rotationSpeed;
    public float angleOfRotation;
    public float rateOfAcceleration;
    public float maxSpeed;
    public float rateOfDeceleration;
    public Vector3 vehiclePosition = new Vector3(0, 0, 0);  // Vector3.zero
    public Vector3 direction = new Vector3(1, 0, 0);        // Right, 0 degrees
    public Vector3 velocity = new Vector3(0, 0, 0);
    public Vector3 acceleration = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateVehicle();
        Drive();
        Wrap();
        SetTransform();
    }

    public void RotateVehicle()
    {
        // left arrow = however many degrees to the left
        // right arrow = however many degrees to the right
        // That severity of rotation depends on rotation speed
        if (Input.GetKey(KeyCode.A))
        {
            direction = Quaternion.Euler(0, 0, rotationSpeed) * direction;
            angleOfRotation += rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Quaternion.Euler(0, 0, -rotationSpeed) * direction;
            angleOfRotation -= rotationSpeed;
        }
    }

    public void Drive()
    {
        // Checks for input
        if (Input.GetKey(KeyCode.W))
        {
            // Only applies acceleration when the key is held down/pressed
            acceleration = rateOfAcceleration * direction;

            velocity += acceleration;

            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

            vehiclePosition += velocity;
        }
        // When the up key is not pressed, deceleration is applied on each frame
        else
        {
            velocity = velocity * rateOfDeceleration;
            // To prevent infinite deceleration, checks for a very, very close instance near 0 for
            // each paramater of velocity. If all are adequately close to 0, the velocity is set to 0
            if ((velocity.x < .00001f && velocity.x > -.00001f) &&
                (velocity.y < .00001f && velocity.y > -.00001f) &&
                (velocity.z < .00001f && velocity.z > -.00001f))
                velocity = new Vector3(0, 0, 0);
            vehiclePosition += velocity;
        }
    }

    public void SetTransform()
    {
        //Rotate the vehicle to face the right direction
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);

        transform.position = vehiclePosition;
    }

    public void Wrap()
    {
        // Set the values for camera, width and height
        Camera view = Camera.current;
        float viewHeight = 2f * view.orthographicSize;
        float viewWidth = viewHeight * view.aspect;

        // Height and width values have to be divided by 2, as it is the height/width spanning the
        // whole camera view
        if (vehiclePosition.x > viewWidth / 2)
        {
            vehiclePosition = new Vector3(-viewWidth / 2, vehiclePosition.y, vehiclePosition.z);
        }
        else if (vehiclePosition.x < -viewWidth / 2)
        {
            vehiclePosition = new Vector3(viewWidth / 2, vehiclePosition.y, vehiclePosition.z);
        }

        if (vehiclePosition.y > viewHeight / 2)
        {
            vehiclePosition = new Vector3(vehiclePosition.x, -viewHeight / 2, vehiclePosition.z);
        }
        else if (vehiclePosition.y < -viewHeight / 2)
        {
            vehiclePosition = new Vector3(vehiclePosition.x, viewHeight / 2, vehiclePosition.z);
        }
    }
}
