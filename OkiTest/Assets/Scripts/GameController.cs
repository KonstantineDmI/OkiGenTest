using Factory;
using Player;
using Products;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private SpawnController spawnController;

    private void Awake()
    {
        spawnController.OnItemSpawned += Subscribe;
    }

    private void Subscribe(ItemBehaviour item)
    {
        item.OnMouseClicked += player.Grab;
    }
}
