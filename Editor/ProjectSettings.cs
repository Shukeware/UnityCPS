using UnityEditor;

namespace Shuke.Settings
{
	public static class ProjectSettings
	{
		public static T FindAsset<T>() where T : SettingsAsset
		{
			string filter = $"t: {typeof(T).Name}";
			var paths = AssetDatabase.FindAssets(filter);
			UnityEngine.Debug.LogError(filter);

			for (int i = 0; i < paths.Length; i++)
			{
				string path = AssetDatabase.GUIDToAssetPath(paths[i]);
				T target = AssetDatabase.LoadAssetAtPath<T>(path);

				if (target)
					return target;
			}

			return null;
		}

		public static ProjectSettingsData GetData()
		{
			var paths = AssetDatabase.FindAssets($"t: {nameof(ProjectSettingsData)}");
			ProjectSettingsData target = null;

			for (int i = 0; i < paths.Length; i++)
			{
				string path = AssetDatabase.GUIDToAssetPath(paths[i]);
				target = AssetDatabase.LoadAssetAtPath<ProjectSettingsData>(path);

				if (target)
					return target;
			}

			return null;
		}

		public static T GetSettings<T>() where T : SettingsAsset
		{
			ProjectSettingsData settings = GetData();

			if (!settings)
				return null;

			for (int i = 0; i < settings.Count; i++)
			{
				if (settings.Settings[i] is T result)
					return result;
			}

			return null;
		}
	}
}