using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Products
{
    [Serializable]
    public class Item
    {
        public int id;
        public ItemBehaviour prefab;
        public GameObject gameObject;
    }
}
