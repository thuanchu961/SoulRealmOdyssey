using System;

[Serializable]
public class EventMessage 
{
    public EventChanelID eventChanelId;
    public string eventName;
    public EventData data;
}
