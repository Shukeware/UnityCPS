using UnityEditor;
using UnityEngine;

namespace Shuke.Settings
{
	[CustomEditor(typeof(SettingsAsset), true)]
	public class SettingsAssetEditor : Editor
	{
		static readonly GUIContent descriptionLabel = new("Descrição", "Usado apenas nas configurações.");
		SerializedProperty descriptionProperty;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (EditorApplication.isPlaying
				|| descriptionProperty is null)
				return;

			EditorGUILayout.Space(EditorGUIUtility.singleLineHeight * 2);
			EditorGUI.BeginChangeCheck();
			_ = EditorGUILayout.PropertyField(descriptionProperty, descriptionLabel);
			if (EditorGUI.EndChangeCheck())
				serializedObject.ApplyModifiedProperties();
		}

		void OnEnable()
		{
			descriptionProperty = serializedObject.FindProperty("_description");
		}
	}

	[CustomPropertyDrawer(typeof(SettingsAsset), true)]
	public class SettingsAssetPropertyDrawer : PropertyDrawer
	{
		Editor editor = null;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			bool cantDraw = !property.objectReferenceValue || property.displayName.Contains("Element");
			GUIContent newLabel = new(label);

			if (!cantDraw)
				newLabel.text = " ";

			_ = EditorGUI.PropertyField(position, property, newLabel);

			if (cantDraw)
				return;

			property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label);

			if (!property.isExpanded)
				return;

			if (!editor)
				Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor);

			EditorGUI.indentLevel++;

			EditorGUILayout.BeginVertical(GUI.skin.box);
			editor.OnInspectorGUI();
			EditorGUILayout.EndVertical();

			EditorGUI.indentLevel--;
		}
	}
}