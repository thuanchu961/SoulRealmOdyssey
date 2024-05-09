using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void InitOnLoad()
    {
        // Init();
    }

    private List<EventChanel> chanels = new List<EventChanel>();

    private EventChanel GetChanel(EventChanelID chanelId)
    {
        foreach (var channel in chanels)
        {
            if (channel.chanelId.Equals(chanelId))
            {
                return channel;
            }
        }

        var newChanel = new EventChanel()
        {
            chanelId = chanelId
        };

        chanels.Add(newChanel);

        return newChanel;
    }

    public void AddListener(IEventListener listener, params EventChanelID[] eventChanelIds)
    {
        foreach (var chanelId in eventChanelIds)
        {
            GetChanel(chanelId).AddListener(listener);
        }
    }

    public void RemoveListener(IEventListener listener)
    {
        foreach (var chanel in chanels)
        {
            chanel.RemoveListener(listener);
        }
    }

    public void Push(EventChanelID chanel, EventMessage message)
    {
        GetChanel(chanel).PushEvent(message);
    }

    public void Push(EventChanelID chanel, string messageName, object sender, params object[] data)
    {
        GetChanel(chanel).PushEvent(new EventMessage()
        {
            eventChanelId = chanel,
            eventName = messageName,
            data = GetEventData(sender, data),
        });
    }

    EventData GetEventData(object sender, object[] data)
    {
        EventData eventData;
        if (data == null || data.Length == 0)
        {
            eventData = new EventData()
            {
                sender = sender
            };
        }
        else if (data.Length == 1)
        {
            eventData = new EventData()
            {
                sender = sender,
                p0 = data[0],
            };
        }
        else if (data.Length == 2)
        {
            eventData = new EventData()
            {
                sender = sender,
                p0 = data[0],
                p1 = data[1],
            };
        }
        else if (data.Length == 3)
        {
            eventData = new EventData()
            {
                sender = sender,
                p0 = data[0],
                p1 = data[1],
                p2 = data[2],
            };
        }
        else if (data.Length == 4)
        {
            eventData = new EventData()
            {
                sender = sender,
                p0 = data[0],
                p1 = data[1],
                p2 = data[2],
                p3 = data[3],
            };
        }
        else
        {
            eventData = new EventData()
            {
                sender = sender,
                p0 = data[0],
                p1 = data[1],
                p2 = data[2],
                p3 = data[3],
                p4 = data[4],
            };
        }

        return eventData;
    }
}
