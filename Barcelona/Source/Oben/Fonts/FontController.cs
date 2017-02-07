using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FontController : MonoBehaviour
{

	public Font androidFont;
	public Font iosFont;


	// Use this for initialization
	void Start ()
	{
		
		foreach (Text t in GameObject.FindObjectsOfType (typeof (Text)) as Text[]) {
			#if UNITY_ANDROID
			t.font = androidFont;
			#elif UNUTY_IOS
			t.Font = iosFont;
			#endif
		}
	}
}
