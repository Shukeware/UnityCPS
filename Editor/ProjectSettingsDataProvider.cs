using System.Collections.Generic;
using UnityEditor;

namespace Shuke.Settings
{
	public class ProjectSettingsDataProvider : SettingsProvider
	{
		readonly ProjectSettingsData settings;

		readonly SettingsSection[] sections;

		public ProjectSettingsDataProvider(ProjectSettingsData target)
		: base(target.GetPath(), SettingsScope.Project, GetKeywords(target))
		{
			settings = target;
			sections = new SettingsSection[target.Settings.Length];

			for (int i = 0; i < sections.Length; i++)
			{
				sections[i] = new SettingsSection(target.Settings[i]);
			}
		}

		[SettingsProvider]
		public static SettingsProvider CreateProvider()
		{
			var paths = AssetDatabase.FindAssets($"t: {nameof(ProjectSettingsData)}");
			ProjectSettingsData target = ProjectSettings.GetData();

			return target ? new ProjectSettingsDataProvider(target) : null;
		}

		static IEnumerable<string> GetKeywords(ProjectSettingsData settings)
		{
			List<string> keywords = new();
			var path = settings.GetPath().Split('/');

			foreach (string s in path)
				keywords.Add(s);

			return keywords;
		}

		public override void OnGUI(string searchContext)
		{
			base.OnGUI(searchContext);

			for (int i = 0; i < sections.Length; i++)
			{
				sections[i].OnGUI();
			}
		}
	}
}