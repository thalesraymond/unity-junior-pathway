using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 25f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField, Min(0f)] private float acceleration = 10f;
    [SerializeField, Min(0f)] private float coastDeceleration = 3f;

    [SerializeField] private InputAction moveAction;


    private float currentSpeed;

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        this.ControlVehicle();
    }

    private void ControlVehicle()
    {
        var inputVector = moveAction.ReadValue<Vector2>();
        var horizontalInput = inputVector.x;
        var verticalInput = inputVector.y;

        var targetSpeed = verticalInput * speed;
        var speedChangeRate = Mathf.Approximately(verticalInput, 0f)
            ? coastDeceleration
            : acceleration;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, speedChangeRate * Time.deltaTime);

        // Keep moving while gradually slowing down after releasing the throttle.
        transform.Translate(Vector3.forward * (currentSpeed * Time.deltaTime));

        // Rotate the vehicle left/right
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }
}
