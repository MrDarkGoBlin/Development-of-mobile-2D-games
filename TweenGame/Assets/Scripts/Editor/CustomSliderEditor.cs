using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(CustomSlider))]
public class CustomSliderEditor : SliderEditor
{
    private SerializedProperty m_InteractableProperty;

    protected override void OnEnable()
    {
        m_InteractableProperty = serializedObject.FindProperty("m_Interactable");
    }

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        var colorOnClick = new PropertyField(serializedObject.FindProperty(CustomSlider.ColorOnClick));
        var imageBur = new PropertyField(serializedObject.FindProperty(CustomSlider.ImageBur));
        var duration = new PropertyField(serializedObject.FindProperty(CustomSlider.Duration));

        var tweenLabel = new Label("Settings Tween");
        var intractableLabel = new Label("Intractable");

        root.Add(tweenLabel);
        root.Add(colorOnClick);
        root.Add(imageBur);
        root.Add(duration);

        root.Add(intractableLabel);
        root.Add(new IMGUIContainer(OnInspectorGUI));

        return root;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(m_InteractableProperty);

        EditorGUI.BeginChangeCheck();

        serializedObject.ApplyModifiedProperties();
    }
}
