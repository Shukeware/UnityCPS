using UnityEditor;
using UnityEngine;

namespace Shuke.Settings
{
	public class SettingsSection
	{
		readonly GUIContent header;
		readonly SerializedObject serializedObject;

		public SettingsSection(SettingsAsset settings)
		{
			serializedObject = new SerializedObject(settings);

			var property = serializedObject.FindProperty("_description");
			string description = property.stringValue;

			header = new GUIContent(settings.name, description);
		}

		public void OnGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField(header, EditorStyles.boldLabel);
			EditorGUI.indentLevel++;

			var property = serializedObject.GetIterator();
			property.NextVisible(true);

			EditorGUI.BeginChangeCheck();
			while (property.NextVisible(true))
			{
				_ = EditorGUILayout.PropertyField(property);
			}

			if (EditorGUI.EndChangeCheck())
			{
				serializedObject.ApplyModifiedProperties();
			}

			EditorGUI.indentLevel--;
		}
	}
}