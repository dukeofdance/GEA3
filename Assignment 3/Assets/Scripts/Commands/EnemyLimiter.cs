using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLimiter : MonoBehaviour
{
    public static void Increase()
    {
        EnemySpawner.enemyLimit++;
    }

    public static void Decrease()
    {
        if (EnemySpawner.enemyLimit <= 0)
        {
            EnemySpawner.enemyLimit= 1;
        }
        else
        {
            EnemySpawner.enemyLimit--;
        }
    }
}
