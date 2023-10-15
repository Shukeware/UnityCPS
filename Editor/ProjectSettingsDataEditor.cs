using UnityEditor;
using UnityEditor.Callbacks;

namespace Shuke.Settings
{
	[CustomEditor(typeof(ProjectSettingsData))]
	public class ProjectSettingsDataEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			EditorGUILayout.HelpBox("Este arquivo deve ficar em um Assembly de Editor", MessageType.Warning);
		}

		[OnOpenAsset]
		static bool Open(int instanceID, int line)
		{
			if (EditorUtility.InstanceIDToObject(instanceID) is not ProjectSettingsData settings)
				return false;

			SettingsService.OpenProjectSettings(settings.GetPath());
			return true;
		}
	}
}