using UnityEngine;

public class Carrot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float rotationSpeed = 20f;

    private Camera _mainCamera;
    private float _cameraHeight;
    private float _spriteHeight;

    private void Start()
    {
        _mainCamera = Camera.main;
        _cameraHeight = _mainCamera.orthographicSize * 2;
        _spriteHeight = spriteRenderer.bounds.size.y;
    }

    private void Update()
    {
        LeanTween.rotateAround(gameObject, Vector3.forward, rotationSpeed * Time.deltaTime, 0f);

        if (IsBelowCamera())
        {
            Destroy(gameObject);
        }
    }

    private bool IsBelowCamera()
    {
        return transform.position.y < -_cameraHeight / 2 - _spriteHeight / 2;
    }
}
