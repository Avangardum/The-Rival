using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MonologueController : SingletonMonoBehaviour<MonologueController>
{
    public bool IsMonologueActive { get; private set; }

    [SerializeField] private GameObject _monologueWindow;

    private Text _monologueWindowText;
    private bool _shouldGonext;

    protected override void Awake()
    {
        base.Awake();
        _monologueWindowText = _monologueWindow.GetComponentInChildren<Text>();
    }

    public void ShowMonologue(params string[] monologueParts)
    {
        StartCoroutine(nameof(ShowMonologueCoroutine), monologueParts);
    }

    private IEnumerator ShowMonologueCoroutine(string[] monologueParts)
    {
        IsMonologueActive = true;
        PauseController.Instance.IsPaused = true;
        _monologueWindow.SetActive(true);
        _shouldGonext = false;
        foreach(string part in monologueParts)
        {
            _monologueWindowText.text = part;
            while (!_shouldGonext)
                yield return new WaitForEndOfFrame();
            _shouldGonext = false;
        }
        _monologueWindow.SetActive(false);
        PauseController.Instance.IsPaused = false;
        IsMonologueActive = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _shouldGonext = true;
    }
}
