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


        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnSpeed);
                var randomItem = factory.GetRandomItem();
                var prefab = factory.Get(randomItem.id);
                prefab.transform.position = spawnPoint.transform.position;
            }
        }
    }
}

