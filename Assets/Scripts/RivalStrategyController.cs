using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalStrategyController : SingletonMonoBehaviour<RivalStrategyController>
{
    public IRivalStrategy Strategy { get; set; }

    private void Update()
    {
        if (PauseController.Instance.IsPaused)
            return;
        Strategy.FrameAction();
    }
}
