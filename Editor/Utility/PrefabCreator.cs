namespace Tilia.Visuals.InteractableHighlighter.Utility
{
    using System.IO;
    using UnityEditor;
    using Zinnia.Utility;

    public class PrefabCreator : BasePrefabCreator
    {
        private const string group = "Tilia/";
        private const string project = "Interactions/Visuals/";
        private const string menuItemRoot = topLevelMenuLocation + group + subLevelMenuLocation + project;

        private const string package = "io.extendreality.tilia.visuals.interactablehighlighter.unity";
        private const string baseDirectory = "Runtime";
        private const string prefabDirectory = "Prefabs";
        private const string prefabSuffix = ".prefab";

        private const string prefabInteractableHighlighter = "Visuals.InteractableHighlighter";

        [MenuItem(menuItemRoot + prefabInteractableHighlighter, false, priority)]
        private static void AddInteractableHighlighter()
        {
            string prefab = prefabInteractableHighlighter + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }
    }
}