using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("General Settings:")]
    [Space]
    
    [SerializeField] private Transform _target;
    
    [Space]
    [Header("Spawn Settings:")]
    [Space]
    
    [SerializeField] private Platform _platfromPrefab;
    
    [SerializeField] private int _stepsCountToSpawn;
    [SerializeField] private float _stepsCountToDelete;
    [SerializeField] private float _stepHeight;
    [SerializeField] private Vector2 _bounds;
    
    private Queue<Platform> _spawnedPlatforms;
    private float _lastPlatformsSpawnedOnPlayerPosition;
    private float _lastPlatformsDeletedOnPlayerPosition;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _spawnedPlatforms = new Queue<Platform>();
        _lastPlatformsDeletedOnPlayerPosition = _lastPlatformsSpawnedOnPlayerPosition = _target.position.y;

        for (int i = 0; i < _stepsCountToSpawn; i++)
        {
            SpawnedPlatforms(i + 1);
        }
        
    }

    private void SpawnedPlatforms(int stepsCount)
    {
        float platformPositionX = Random.Range(_bounds.x, _bounds.y);
        float platformPositionY = _target.position.y + stepsCount * _stepHeight;
        
        Vector3 platformPosition = new Vector3(platformPositionX, platformPositionY, _target.position.z);
        Platform spawnedPlatform = Instantiate(_platfromPrefab, platformPosition, Quaternion.identity, this.transform);
        
        spawnedPlatform.Init(_target);
        _spawnedPlatforms.Enqueue(spawnedPlatform);
    }

    void Update()
    {
        if (_target.position.y - _lastPlatformsSpawnedOnPlayerPosition > _stepHeight)
        {
            SpawnedPlatforms(_stepsCountToSpawn);
            _lastPlatformsSpawnedOnPlayerPosition += _stepHeight;
        }

        if (_target.position.y - _lastPlatformsDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete)
        {
            var platformToDelete = _spawnedPlatforms.Dequeue();
            
            if (platformToDelete && platformToDelete.gameObject)
            {
                Destroy(platformToDelete.gameObject);
            }

            _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
        }
    }
}
