using Products;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class GameObjectsFactory : ScriptableObject
    {
        public ItemBehaviour InstantiateItem(ItemBehaviour prefab)
        {
            var variant = Instantiate(prefab);
            return variant;
        }
    }
}
