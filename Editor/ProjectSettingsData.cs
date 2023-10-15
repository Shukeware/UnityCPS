using UnityEngine;

namespace Shuke.Settings
{
	[CreateAssetMenu(menuName = "Shuke/Settings/ProjectSettings")]
	public class ProjectSettingsData : ScriptableObject
	{
		[field: SerializeField]
		public SettingsAsset[] Settings { get; private set; }

		public int Count => Settings.Length;

		public string GetPath()
		{
			return $"Project/{name}";
		}
	}
}