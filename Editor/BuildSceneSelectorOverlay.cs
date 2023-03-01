using UnityEditor;
using UnityEngine;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using System;
using UnityEngine.UIElements;
using System.IO;
using UnityEditor.SceneManagement;

[Overlay(typeof(SceneView), "Build Scene Selector")]
public class BuildSceneSelectorOverlay : Overlay
{
    public override VisualElement CreatePanelContent()
    {
        VisualElement root = new VisualElement();

        foreach (EditorBuildSettingsScene sceneSelector in EditorBuildSettings.scenes)
        {
            var button = new Button();
            button.clicked += () => EditorSceneManager.OpenScene(sceneSelector.path);
            button.text = Path.GetFileNameWithoutExtension(sceneSelector.path);
            root.Add(button);
        }
        
        return root;
    }
}
