using Products;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Cart : MonoBehaviour
{
    [SerializeField] private ParticleSystem increaseParticles;
    [SerializeField] private ParticleSystem decreaseParticles;
    [SerializeField] private Transform particlesPoint;

    private List<ItemBehaviour> _items = new List<ItemBehaviour>();

    public event Action<ItemBehaviour> OnCartUpdated;

    public int targetItemId;

    public void AddItem(ItemBehaviour item)
    {
        OnCartUpdated?.Invoke(item);
        if (item.id != targetItemId)
        {
            return;
        }
        _items.Add(item);
        CreateParticles(increaseParticles);
    }

    public void RemoveFromCart()
    {
        if(!_items.FindAll(x => x.id == targetItemId).Any())
        {
            return;
        }
        var itemToRemove = _items.Find(x => x.id == targetItemId);

        _items.Remove(itemToRemove);
        Destroy(itemToRemove.gameObject);
        CreateParticles(decreaseParticles);
    }

    private void CreateParticles(ParticleSystem particles)
    {
        Instantiate(particles, particlesPoint.position, transform.rotation).Play();
    }
} 
