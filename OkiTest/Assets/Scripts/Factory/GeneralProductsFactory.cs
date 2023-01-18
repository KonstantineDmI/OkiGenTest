using Products;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    [CreateAssetMenu]
    public class GeneralProductsFactory : ProductFactory
    {
        [SerializeField] private List<Item> items;
        protected override Item GetConfig(int configId)
        {
            return items.Find(x => x.id == configId);
        }

        public override Item GetRandomItem()
        {
            return items[Random.Range(0, items.Count)];
        }
    }
}
