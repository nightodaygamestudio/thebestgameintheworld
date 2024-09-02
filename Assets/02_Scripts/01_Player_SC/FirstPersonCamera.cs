using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour, i_Update
{

    public float sensitivity = 5.0f;

    private Vector2 mouseInput;
    private float pitch;
    private void Start()
    {
        UpdateManager.Instance.RegisterUpdate(this);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        UpdateManager.Instance.UnregisterUpdate(this);
    }

    public void CostumUpdate()
    {
        CameraLooking();
    }

    public void CameraLooking()
    {
        transform.Rotate(Vector3.up, mouseInput.x * sensitivity * Time.deltaTime);
        pitch -= mouseInput.y * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.localEulerAngles = new Vector3(pitch, transform.eulerAngles.y, 0f);
    }
    public void OnMouseMove(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }
}
