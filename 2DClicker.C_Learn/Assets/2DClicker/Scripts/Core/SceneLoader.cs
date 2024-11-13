using Common.Assets;
using Common.Path;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

namespace Common.SceneEx
{
    public static class SceneLoader
    {
        public readonly static SortedList<LoadPriorityType, Func<Scene, UniTask>> completedList = new SortedList<LoadPriorityType, Func<Scene, UniTask>>();

        public static void Init()
        {
            Add(LoadPriorityType.BaseScene, LoadScene);

            SceneManager.sceneLoaded += OnLoadCompleted;
        }

        public static void Add(LoadPriorityType type, Func<Scene, UniTask> loadCompleted)
        {
            if (completedList.ContainsKey(type))
            {
                Debug.LogWarning($"There is already an identical LoadCompleted event : {type}");
                return;
            }

            completedList.Add(type, loadCompleted);
        }

        public static bool Remove(LoadPriorityType type)
        {
            if (completedList[type] == null)
            {
                Debug.LogError($"Is Not found competedList : {type}");
                return false;
            }

            completedList.Remove(type);
            return true;
        }


        private static async void OnLoadCompleted(Scene scene, LoadSceneMode sceneMode)
        {
            foreach (var item in completedList)
            {
                try
                {
                    await item.Value.Invoke(scene);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        private static async UniTask LoadScene(Scene scene)
        {
            GameObject go = await AddressableAssets.InstantiateAsync(AdressablePath.ScenePath(scene.name));

            if (!go.TryGetComponent(out IUniTaskInit baseScene))
            {
                Debug.LogError($"GameObject Is Not BaseScene Inheritance : {go}");
                return;
            }

            await baseScene.Init();
        }
    }
}