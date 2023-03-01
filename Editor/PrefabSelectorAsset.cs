using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabSelectorAsset", menuName = "Selector/PrefabSelectorAsset", order = 0)]
public class PrefabSelectorAsset : ScriptableObject
{
    [SerializeField] List<GameObject> gameObjects = new List<GameObject>();

    public static IEnumerable<GameObject> GameObjects { get => instance.gameObjects; }

    #region StaticScriptableObject
    protected static PrefabSelectorAsset instance
    {
        get
        {
            if (m_instance == null)
            {
                var array = Resources.LoadAll<PrefabSelectorAsset>("");
                if (array.Length == 0)
                {
                    Debug.LogError("<color=red>" + typeof(PrefabSelectorAsset) + " has been accessed, but there was an error:</color>");
                    Debug.LogError("<color=red>A static scriptable object should be present in the Resources folder.</color>");
                }
                else
                {
                    m_instance = array[0];
                }
            }

            return m_instance;
        }
    }

    private static PrefabSelectorAsset m_instance;
    #endregion
}
