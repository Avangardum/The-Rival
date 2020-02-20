using UnityEngine;
using UnityEngine.UI;

public class NewSkillNotificationController : SingletonMonoBehaviour<NewSkillNotificationController>
{
    public bool IsNotificationActive { get; private set; }

    [SerializeField] private Text _title;
    [SerializeField] private Text _body;
    [SerializeField] private float _minShowTime;

    private float _timePassedFromLastShow;

    protected override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
    }

    public void ShowNotification(string title, string body)
    {
        PauseController.Instance.Pause();
        gameObject.SetActive(true);
        _title.text = title;
        _body.text = body;
        _timePassedFromLastShow = 0f;
        IsNotificationActive = true;
    }

    public void HideNotification()
    {
        PauseController.Instance.Unpause();
        gameObject.SetActive(false);
        IsNotificationActive = false;
    }

    public void ShowNotification(NewSkillNotification newSkillNotification) => ShowNotification(newSkillNotification.Title, newSkillNotification.Body);

    private void Update()
    {
        _timePassedFromLastShow += Time.unscaledDeltaTime;
        if (Input.GetMouseButtonDown(0) && _timePassedFromLastShow >= _minShowTime)
            HideNotification();
        if(IsNotificationActive)
            _timePassedFromLastShow += Time.unscaledDeltaTime;
    }
}
