using UnityEditor;
using UnityEngine;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using System;
using UnityEngine.UIElements;
using System.IO;
using UnityEditor.SceneManagement;

[Overlay(typeof(SceneView), "Scene Selector")]
public class SceneSelectorOverlay : Overlay
{
    public override VisualElement CreatePanelContent()
    {
        VisualElement root = new VisualElement();

        foreach (SceneAsset sceneSelector in SceneSelectorAsset.Scenes)
        {
            string path = AssetDatabase.GetAssetOrScenePath(sceneSelector);
            var button = new Button();
            button.clicked += () => EditorSceneManager.OpenScene(path);
            button.text = Path.GetFileNameWithoutExtension(path);
            root.Add(button);
        }
        
        return root;
    }
}
