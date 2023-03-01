using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneSelectorAsset", menuName = "Selector/SceneSelectorAsset", order = 0)]
public class SceneSelectorAsset : ScriptableObject
{
    [SerializeField] List<SceneAsset> scenes = new List<SceneAsset>();

    public static IEnumerable<SceneAsset> Scenes { get => instance.scenes; }

    #region StaticScriptableObject
    protected static SceneSelectorAsset instance
    {
        get
        {
            if (m_instance == null)
            {
                var array = Resources.LoadAll<SceneSelectorAsset>("");
                if (array.Length == 0)
                {
                    Debug.LogError("<color=red>" + typeof(SceneSelectorAsset) + " has been accessed, but there was an error:</color>");
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

    private static SceneSelectorAsset m_instance;
    #endregion
}
