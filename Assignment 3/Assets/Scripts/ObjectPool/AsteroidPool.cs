using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    [SerializeField]
    private  Projectile prefab;
    private static Queue<Projectile> availableObjects = new Queue<Projectile>();

    public static AsteroidPool Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    public  Projectile GetFromPool()
    {
        if (availableObjects.Count == 0)
            GrowPool();
        var instance = availableObjects.Dequeue();
        instance.gameObject.SetActive(true);
        return instance;
    }

    private  void GrowPool()
    {
        Vector3 spawnLocation = EnemySpawner.v;
        var instanceToAdd = Instantiate(prefab, spawnLocation, Quaternion.identity);
        instanceToAdd.transform.SetParent(transform);
        AddToPool(instanceToAdd);
    }

    public static void AddToPool(Projectile instance)
    {
        instance.gameObject.SetActive(false);
        availableObjects.Enqueue(instance);
    }
}
