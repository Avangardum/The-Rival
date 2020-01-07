using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location3Controller : MonoBehaviour
{
    [SerializeField] private string[] _introMonologue;
    [SerializeField] private string[] _endMonologue;
    [SerializeField] private NewSkillNotification _dashNotification;
    [SerializeField] private NewSkillNotification _fullCoveringNotification;
    [SerializeField] private NewSkillNotification _levitationNotification;
    [SerializeField] private NewSkillNotification _repulsionBombNotification;

    private void Start()
    {
        BacktrackingController.Instance.ActiveCheckpoint = new Checkpoint(SceneLoader.Instance.ReloadScene);
        MonologueController.Instance.ShowMonologue(_introMonologue);
    }

    public void End()
    {
        StartCoroutine(EndCoroutine());
    }

    private IEnumerator EndCoroutine()
    {
        MonologueController.Instance.ShowMonologue(_endMonologue);
        yield return new WaitWhile(() => MonologueController.Instance.IsMonologueActive);
        NewSkillNotificationController.Instance.ShowNotification(_dashNotification);
        yield return new WaitWhile(() => NewSkillNotificationController.Instance.IsNotificationActive);
        NewSkillNotificationController.Instance.ShowNotification(_fullCoveringNotification);
        yield return new WaitWhile(() => NewSkillNotificationController.Instance.IsNotificationActive);
        NewSkillNotificationController.Instance.ShowNotification(_levitationNotification);
        yield return new WaitWhile(() => NewSkillNotificationController.Instance.IsNotificationActive);
        NewSkillNotificationController.Instance.ShowNotification(_repulsionBombNotification);
        yield return new WaitWhile(() => NewSkillNotificationController.Instance.IsNotificationActive);
        SceneLoader.Instance.LoadScene("Location 4");
    }
}
