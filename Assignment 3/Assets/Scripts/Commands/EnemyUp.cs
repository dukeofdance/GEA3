using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUp : ICommand
{
    public void Execute()
    {
        EnemyLimiter.Increase();
    }


    public void Undo()
    {
        EnemyLimiter.Decrease();
    }

}
