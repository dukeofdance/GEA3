using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private Projectile prefab;

    [SerializeField]
    private Transform bulletLocation;

    private static Queue<Projectile> availableObjects = new Queue<Projectile>();

    public static BulletPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    public Projectile GetFromPool()
    {
        if (availableObjects.Count == 0)
            GrowPool();
        var instance = availableObjects.Dequeue();
        instance.gameObject.SetActive(true);
        return instance;
    }

    private void GrowPool(){
        Quaternion quat = Quaternion.Euler(0, 90, 90);
        for (int i = 0; i < 5; i++)
        {
            var instanceToAdd = Instantiate(prefab, bulletLocation.transform.position, quat);
            AddToPool(instanceToAdd);
        }
    }

    public static void AddToPool(Projectile instance)
    {
        instance.gameObject.SetActive(false);
        availableObjects.Enqueue(instance);
        Debug.Log("reloaded");
    }
}
