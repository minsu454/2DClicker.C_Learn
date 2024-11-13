using Common.Assets;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class UIManager : MonoBehaviour, IManager
{
    private readonly List<BasePopupUI> showList = new List<BasePopupUI>();

    public void Init()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        showList.Clear();
        CreateSceneUI(scene.name);
    }

    private async void CreateSceneUI(string name)
    {
        GameObject prefab = await AddressableAssets.InstantiateAsync($"UI/{name}.prefab");

        if (prefab == null)
        {
            Debug.LogError($"Is Not Prefab Addressable Asset Forder : {name}");
            return;
        }

        BaseSceneUI sceneUI = prefab.GetComponent<BaseSceneUI>();

        sceneUI.Init();
    }

    public async void CreatePopup<T>(PopupOption option = null) where T : BasePopupUI
    {
        GameObject prefab = await AddressableAssets.InstantiateAsync($"UI/{typeof(T).Name}.prefab");

        if (prefab == null)
        {
            Debug.LogError($"Is Not Prefab Addressable Asset Forder : {typeof(T).Name}");
            return;
        }

        T popupUI = prefab.GetComponent<T>();
        showList.Add(popupUI);

        popupUI.Init(option);
    }

    public void ClosePopup()
    {
        if (showList.Count == 0)
            return;

        BasePopupUI popup = showList[showList.Count - 1];
        showList.RemoveAt(showList.Count - 1);

        AddressableAssets.Release(popup.gameObject);
        Destroy(popup.gameObject);
    }

    public void ClosePopup<T>(T popup) where T : BasePopupUI
    {
        int idx = showList.Count - 1;

        while (idx == 0)
        {
            if (showList[idx] == popup)
                break;

            idx--;
        }

        if (idx == -1)
            Debug.LogError($"Is Not Found Popup : {typeof(T).Name}");

        showList.RemoveAt(idx);

        AddressableAssets.Release(popup.gameObject);
        Destroy(popup.gameObject);
    }
}
