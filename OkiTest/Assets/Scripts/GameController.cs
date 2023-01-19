using Factory;
using Player;
using Products;
using QuestSystem;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private SpawnController spawnController;
    [SerializeField] private QuestControllerBase questController;
    [SerializeField] private CameraAnimation cameraAnimation;
    [SerializeField] private UIController uiController;
    private void Awake()
    {
        questController.OnQuestComplete += Victory;
        spawnController.OnItemSpawned += SubscribeInput;
    }

    private void SubscribeInput(ItemBehaviour item)
    {
        item.OnMouseClicked += player.Grab;
    }

    private void Victory()
    {
        player.SetVictoryState();
        spawnController.StopSpawner();
        cameraAnimation.FinalAnimation();
        uiController.ActivateContent();
    }
}
