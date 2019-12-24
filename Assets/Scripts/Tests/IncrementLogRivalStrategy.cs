using UnityEngine;

public class IncrementLogRivalStrategy : IRivalStrategy
{
    private int counter = 1;

    public void FrameAction()
    {
        Debug.Log(counter);
        counter++;
    }

    public void Initialize(MonoBehaviour monoBehaviour)
    {

    }
}
