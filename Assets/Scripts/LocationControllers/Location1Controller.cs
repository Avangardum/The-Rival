using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location1Controller : SingletonMonoBehaviour<Location1Controller>
{
    [SerializeField] private string[] _introMonologue;
    [SerializeField] private string[] _phase1EndMonologue;
    [SerializeField] private string[] _endMonologue;
    [SerializeField] private NewSkillNotification swordNotification;
    [SerializeField] private string _nextScene;

    private GameObject _player;

    private void Start()
    {
        BacktrackingController.Instance.ActiveCheckpoint = new Checkpoint(RestartFight1);
        MonologueController.Instance.ShowMonologue(_introMonologue);
        RivalStrategyController.Instance.Strategy = new RivalStrategy1_1_1();
        GameObject.FindGameObjectWithTag("Rival").GetComponent<HealthController>().Death += EndLocation1;
    }

    public void ShowPhase1EndMonologue()
    {
        MonologueController.Instance.ShowMonologue(_phase1EndMonologue);
    }

    public void RestartFight1() => SceneLoader.Instance.ReloadScene();

    public void EndLocation1()
    {
        StartCoroutine(EndLocation1Coroutine());
    }

    private IEnumerator EndLocation1Coroutine()
    {
        MonologueController.Instance.ShowMonologue(_endMonologue);
        yield return new WaitWhile(() => MonologueController.Instance.IsMonologueActive);
        NewSkillNotificationController.Instance.ShowNotification(swordNotification);
        yield return new WaitWhile(() => NewSkillNotificationController.Instance.IsNotificationActive);
        SceneLoader.Instance.LoadScene(_nextScene);
    }
}
