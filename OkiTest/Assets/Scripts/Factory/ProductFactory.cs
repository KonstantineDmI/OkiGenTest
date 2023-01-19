using Products;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public abstract class ProductFactory : GameObjectsFactory
    {
        public ItemBehaviour Get(int configId)
        {
            var config = GetConfig(configId);
            ItemBehaviour instance = InstantiateItem(config.prefab);
            instance.id = config.id;
            return instance;
        }

        protected abstract Item GetConfig(int configId);
        public abstract Item GetRandomItem();

    }
}
