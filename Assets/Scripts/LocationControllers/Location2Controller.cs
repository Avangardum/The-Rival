using System.Collections;
using UnityEngine;

public class Location2Controller : MonoBehaviour
{
    [SerializeField] GameObject _hiddenArea1;
    [SerializeField] GameObject _veryBigBullet;
    [SerializeField] string[] _introMonologue;
    [SerializeField] string[] _battleBeginningMonologue;
    [SerializeField] string[] _battleEndMonologue;
    [SerializeField] NewSkillNotification _insightNotification;
    [SerializeField] NewSkillNotification _fakeBulletsNotification;
    [SerializeField] DoorController _outerDoorController;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        BacktrackingController.Instance.ActiveCheckpoint = new Checkpoint(SceneLoader.Instance.ReloadScene);
        _outerDoorController.DoorOpened += OnOuterDoorOpen;
        _veryBigBullet.GetComponent<BulletController>().Hit += OnVeryBigBulletEscape;
        MonologueController.Instance.ShowMonologue(_introMonologue);
        GameObject.FindGameObjectWithTag("Rival").GetComponent<HealthController>().Death += End;
    }

    private void OnOuterDoorOpen()
    {
        _hiddenArea1.SetActive(false);
        _veryBigBullet.SetActive(true);
    }

    private void OnVeryBigBulletEscape()
    {
        if (_player.GetComponent<HealthController>().IsDead)
            return;
        MonologueController.Instance.ShowMonologue(_battleBeginningMonologue);
        RivalStrategyController.Instance.Strategy = new RivalStrategy2_1_1();
    }

    public void End()
    {
        StartCoroutine(EndCoroutine());
    }

    private IEnumerator EndCoroutine()
    {
        MonologueController.Instance.ShowMonologue(_battleEndMonologue);
        yield return new WaitWhile(() => MonologueController.Instance.IsMonologueActive);
        NewSkillNotificationController.Instance.ShowNotification(_insightNotification);
        yield return new WaitWhile(() => NewSkillNotificationController.Instance.IsNotificationActive);
        NewSkillNotificationController.Instance.ShowNotification(_fakeBulletsNotification);
        yield return new WaitWhile(() => NewSkillNotificationController.Instance.IsNotificationActive);
        SceneLoader.Instance.LoadScene("Location 3");
    }
}
