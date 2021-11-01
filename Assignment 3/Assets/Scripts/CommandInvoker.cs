using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static public List<ICommand> commandHistory;
    static public int counter;

    private void Awake() 
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
    }

    public static void AddCommand(ICommand command)
    {
        while (commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }
        commandBuffer.Enqueue(command);
    }

    // Update is called once per frame
    void Update()
    {

        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();
            
            commandHistory.Add(c);
            counter++;

        }

    }

    public static void UndoCommand()
    {
        if (counter > 0)
        {
            counter--;
            commandHistory[counter].Undo();

        }
    }

}
