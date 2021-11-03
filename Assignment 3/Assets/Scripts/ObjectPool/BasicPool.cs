using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static BasicPool Instance {get; private set;}

    private void Awake(){
        Instance = this;
        GrowPool();
    }

    public GameObject GetFromPool(){
        if(availableObjects.Count == 0)
            GrowPool();

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool(){
        Vector3 spawnLocation = EnemySpawner.v;
        for (int i = 0; i < EnemySpawner.enemyLimit; i++)
        {
            var instanceToAdd = Instantiate(prefab, spawnLocation, Quaternion.Euler(0f, -90f, 90f));
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance){
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
}
