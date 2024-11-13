using Common.Assets;
using Common.Path;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

namespace Common.SceneEx
{
    public static class SceneLoader
    {
        public readonly static SortedList<LoadPriorityType, Action<Scene>> completedList = new SortedList<LoadPriorityType, Action<Scene>>();

        public static void Init()
        {
            Add(LoadPriorityType.BaseScene, LoadScene);

            SceneManager.sceneLoaded += OnLoadCompleted;
        }

        public static void Add(LoadPriorityType type, Action<Scene> loadCompleted)
        {
            if (completedList.ContainsValue(loadCompleted))
            {
                Debug.LogWarning($"There is already an identical LoadCompleted event. : {loadCompleted}");
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


        private static void OnLoadCompleted(Scene scene, LoadSceneMode sceneMode)
        {
            foreach (var item in completedList)
            {
                item.Value.Invoke(scene);
            }
        }

        private static async void LoadScene(Scene scene)
        {
            GameObject go = await AddressableAssets.InstantiateAsync(AdressablePath.ScenePath(scene.name));

            if (!go.TryGetComponent(out IInit baseScene))
            {
                Debug.LogError($"GameObject Is Not BaseScene Inheritance : {go}");
                return;
            }

            baseScene.Init();
        }
    }
}