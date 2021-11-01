using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManage : MonoBehaviour
{
    public static void Increase()
    {
        EnemySpawner.waveTotal++;
    }

    public static void Decrease()
    {
        if (EnemySpawner.waveTotal <= 0)
        {
            EnemySpawner.waveTotal = 1;
        }
        else
        {
            EnemySpawner.waveTotal--;
        }
    }
}
