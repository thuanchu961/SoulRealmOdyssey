using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using System;
public class GameAdapter : Adapter
{
    public override T GetData<T>(int turn)
    {
        T data;

        Type type = typeof(T);
        if (type == typeof(GameInitStateData))
        {
            GameInitStateData initStateData = new();
            data = ConvertToType<T>(initStateData);
        }
        else
        {
            data = ConvertToType<T>(null);
        }

        return data;
    }

    public override int GetMaxTurn()
    {
        throw new System.NotImplementedException();
    }

    public override void SetData<T>(T data)
    {
        throw new System.NotImplementedException();
    }
}
