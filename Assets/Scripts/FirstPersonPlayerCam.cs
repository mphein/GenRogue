using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayerCam : MonoBehaviour
{

    public float mouseSensitivity = 100.0f;
    public Transform playerBody;

    private float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player's body horizontally based on mouse input
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically based on mouse input
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // Clamp rotation to prevent flipping
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
    }
}
