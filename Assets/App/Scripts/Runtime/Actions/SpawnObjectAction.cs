using App.Scripts.Core.CustomBases;
using UnityEngine;

namespace App.Scripts.Runtime.Actions
{
    public class SpawnObjectAction : ActionBase
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject[] _prefabPull;
        [SerializeField] private float _skipSpawnChance = 0.7f;

        protected override void ExecuteInternal()
        {
            SpawnRandomObjectFromPull();
        }

        private void SpawnRandomObjectFromPull()
        {
            if (_prefabPull == null || _prefabPull.Length == 0)
            {
                Debug.LogError($"{nameof(SpawnObjectAction)}: No prefab assigned");
                return;
            }

            if (Random.value < _skipSpawnChance)
            {
                return;
            }

            int randomIndex = Random.Range(0, _prefabPull.Length);
            GameObject selectedPrefab = _prefabPull[randomIndex];

            Instantiate(selectedPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
        }
    }
}