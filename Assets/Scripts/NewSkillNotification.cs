using System;

[Serializable]
public struct NewSkillNotification
{
    public string Title;
    public string Body;

    public NewSkillNotification(string title, string body)
    {
        Title = title;
        Body = body;
    }
}
