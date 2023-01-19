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
        public string name;
        public ItemBehaviour prefab;
        public Sprite sprite;
    }
}
