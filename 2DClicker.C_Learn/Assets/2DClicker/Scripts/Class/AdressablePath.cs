using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Path
{
    public static class AdressablePath
    {
        public static string ScenePath(string name)
        {
            return $"Scene/{name}Scene.prefab";
        }

        public static string UIPath(string name)
        {
            return $"UI/{name}.prefab";
        }

        public static string EnemyPath(string name)
        {
            return $"Enemy/{name}.prefab";
        }

        public static string PlayerPath(string name)
        {
            return $"Player/{name}.prefab";
        }
    }
}

