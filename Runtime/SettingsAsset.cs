using UnityEngine;

namespace Shuke.Settings
{
	public abstract class SettingsAsset : ScriptableObject
	{
#if UNITY_EDITOR
		[SerializeField]
		[HideInInspector]
		[TextArea]
		string _description;
#endif
	}
}