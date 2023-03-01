using UnityEditor;
using UnityEngine;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using System;
using UnityEngine.UIElements;
using System.IO;
using UnityEditor.SceneManagement;

[Overlay(typeof(SceneView), "Prefab Selector")]
public class PrefabSelectorOverlay : Overlay
{
    public override VisualElement CreatePanelContent()
    {
        VisualElement root = new VisualElement();

        foreach (GameObject prefab in PrefabSelectorAsset.GameObjects)
        {
            var button = new Button();
            button.clicked += () => AssetDatabase.OpenAsset(prefab);
            button.text = prefab.name;
            root.Add(button);
        }

        return root;
    }
}