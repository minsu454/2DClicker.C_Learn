using Common.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : BaseSceneUI
{
    public void CreatePopup()
    {
    }

    public void NextScene()
    {
        SceneManagerEx.LoadingAndNextScene(SceneType.Title);
    }
}
