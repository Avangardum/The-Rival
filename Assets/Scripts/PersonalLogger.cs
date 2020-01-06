using UnityEngine;

public class PersonalLogger : MonoBehaviour
{
    [SerializeField] [TextArea] private string _log = "";

    public void Log(string message)
    {
        _log += message;
        _log += "\n";
    }
}
