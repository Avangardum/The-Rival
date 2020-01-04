using UnityEngine;
using UnityEngine.UI;

public class NewSkillNotificationController : SingletonMonoBehaviour<NewSkillNotificationController>
{
    public bool IsNotificationActive { get; private set; }

    [SerializeField] private Text _title;
    [SerializeField] private Text _body;

    private float _timePassedFromLastShow;

    protected override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
    }

    public void ShowNotification(string title, string body)
    {
        gameObject.SetActive(true);
        _title.text = title;
        _body.text = body;
        _timePassedFromLastShow = 0f;
        IsNotificationActive = true;
    }

    public void HideNotification()
    {
        gameObject.SetActive(false);
        IsNotificationActive = false;
    }

    public void ShowNotification(NewSkillNotification newSkillNotification) => ShowNotification(newSkillNotification.Title, newSkillNotification.Body);

    private void Update()
    {
        _timePassedFromLastShow += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && _timePassedFromLastShow >= 1)
            HideNotification();
    }
}
