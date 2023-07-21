using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class LobbyScene : BaseScene
{
    private void Update()
    {
    }
    
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;
    }

    public override void Clear()
    {
        Debug.Log("[장시진] LobbyScene Clear!");
    }
}
