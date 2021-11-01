using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesUp : ICommand
{

    public void Execute()
    {
        WaveManage.Increase();
    }

    public void Undo()
    {
        WaveManage.Decrease();
    }
}
