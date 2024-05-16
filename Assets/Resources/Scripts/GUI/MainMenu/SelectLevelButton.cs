using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
public class SelectLevelButton : AbstractBaseButton
{
    [SerializeField] private Constant.SCENE scene;
    protected override void OnClick()
    {
        UserInputChanel selectLevel = new(UserInputChanel.SELECT_LEVEL_CLICK, ((int)scene));
        ObserverManager.TriggerEvent<UserInputChanel>(selectLevel);
    }

}
