using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick Movementjoystick;
    public Joystick Rotationjoystick;
    public float speed = 5f;
    public float rotationSpeed = 0.001f;
    private CharacterController controller;
    private float verticalRotation = 50f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleRotation()
    {
        float rotationX = Rotationjoystick.Horizontal * rotationSpeed;
        float rotationY = Rotationjoystick.Vertical * rotationSpeed;

        transform.Rotate(Vector3.up, rotationX);
        verticalRotation -= rotationY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
    void HandleMovement()
    {
        float moveX = Movementjoystick.Horizontal;
        float moveZ = Movementjoystick.Vertical;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);
    }
}
