using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.InGame;
    }

    public override void Clear()
    {
        Debug.Log("[장시진] InGameScene Clear!");
    }
}
