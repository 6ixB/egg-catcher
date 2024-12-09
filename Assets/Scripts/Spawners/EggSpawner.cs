using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;
    public float spawnInterval = 1f;

    private Camera _mainCamera;
    private float _cameraRelativeWidth;
    private float _spriteWidth;

    private void Start()
    {
        _mainCamera = Camera.main;
        _cameraRelativeWidth = _mainCamera.orthographicSize * _mainCamera.aspect;
        _spriteWidth = eggPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        InvokeRepeating(nameof(SpawnEgg), 0f, spawnInterval);
    }

    private void SpawnEgg()
    {
        float randomX = Random.Range(
            _mainCamera.transform.position.x - _cameraRelativeWidth + _spriteWidth / 2,
            _mainCamera.transform.position.x + _cameraRelativeWidth - _spriteWidth / 2
        );

        float spawnY = _mainCamera.transform.position.y + _mainCamera.orthographicSize * 2;

        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(eggPrefab, spawnPosition, Quaternion.identity);
    }
}
