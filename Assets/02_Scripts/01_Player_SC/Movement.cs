using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour, i_Update
{
    [Header("Objects")]
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform _cameraTransform;
    private Vector2 _moveInput;
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); rb = GetComponent<Rigidbody>(); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    public void CostumUpdate()
    {
        Moving();
    }
    public void Moving()
    {
        Vector3 move = _cameraTransform.forward * _moveInput.y + _cameraTransform.right * _moveInput.x;
        move.y = 0f;
        rb.AddForce(move.normalized * moveSpeed, ForceMode.VelocityChange);
    }
    public void OnMove(InputAction.CallbackContext context) { _moveInput = context.ReadValue<Vector2>(); }
}
