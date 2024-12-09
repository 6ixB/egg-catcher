using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    public float movementSpeed;
    public InputActionReference moveAction;

    private Vector2 _moveDirection;
    private Camera _mainCamera;
    private float _spriteWidth;
    private float _positionClampMin;
    private float _positionClampMax;

    private void Start()
    {
        _mainCamera = Camera.main;
        _spriteWidth = spriteRenderer.bounds.size.x;

        float cameraRelativeWidth = _mainCamera.orthographicSize * _mainCamera.aspect;
        _positionClampMin = -cameraRelativeWidth + _spriteWidth / 2;
        _positionClampMax = cameraRelativeWidth - _spriteWidth / 2;
    }

    private void Update()
    {
        _moveDirection = moveAction.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (rigidBody.position.x >= _positionClampMin && rigidBody.position.x <= _positionClampMax)
        {
            float velocityX = _moveDirection.x * movementSpeed;
            float velocityY = _moveDirection.y * movementSpeed;
            rigidBody.velocity = new Vector2(velocityX, velocityY);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }

        ClampPlayerToCameraBounds();
    }

    private void ClampPlayerToCameraBounds()
    {
        Vector3 currentPosition = rigidBody.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, _positionClampMin, _positionClampMax);
        rigidBody.position = currentPosition;
    }
}
