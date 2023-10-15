using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shuke.Settings;

[CreateAssetMenu(menuName="Shuke/Settings/SampleSettings")]
public class SampleSettings : SettingsAsset
{
	[field: Tooltip("Teste de string")]
	[field: SerializeField]
	public string TestString { get; private set; }

	[field: Tooltip("Teste de int")]
	[field: SerializeField]
	public int TestInt { get; private set; }
	
	[field: Tooltip("Teste de int com slider")]
	[field: Range(1, 10)]
	[field: SerializeField]
	public int TestIntSlide { get; private set; }
}
