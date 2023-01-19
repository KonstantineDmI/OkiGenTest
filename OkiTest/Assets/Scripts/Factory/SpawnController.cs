using Products;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Factory
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private float spawnSpeed;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GeneralProductsFactory factory;

        private List<ItemBehaviour> _items = new List<ItemBehaviour>();

        public event Action<ItemBehaviour> OnItemSpawned;

        private Coroutine _spawnRoutine;

        private void Start()
        {
           _spawnRoutine = StartCoroutine(SpawnCoroutine());
        }

        public void StopSpawner()
        {
            StopCoroutine(_spawnRoutine);
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnSpeed);
                var randomItem = factory.GetRandomItem();
                var prefab = factory.Get(randomItem.id);
                _items.Add(prefab);
                prefab.OnDestroyAction += RemoveItem;
                OnItemSpawned?.Invoke(prefab);
                prefab.transform.position = spawnPoint.transform.position;
            }
        }

        private void RemoveItem(ItemBehaviour item)
        {
            _items.Remove(item);
        }
    }
}

