using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Txt360 : MonoBehaviour {
	public string txtFile = "dato";
	string txtContents;


	// Use this for initialization
	void Start () {
		TextAsset txtAssets = (TextAsset)Resources.Load(txtFile);
		txtContents = txtAssets.text;
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUILayout.Label (txtContents);
	}
}
