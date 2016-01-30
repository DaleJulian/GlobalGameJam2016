using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour {

	public Text UIText;

	private Dictionary<string, string> TextList = new Dictionary<string, string>();

	public void Start() {
		UIText = GameObject.Find("Tooltip Text").GetComponent<Text>();
		UIText.text = "";

		TextList.Add("Eye", "I need to find chuvaness eye.");

		UIText.text = TextList["Eye"];
		//TODO script
	}

	public void toggleText(string key) {
		if(TextList.ContainsKey("key")) {
			UIText.text = TextList[key];
		}
	}

	public void turnOffText() {
		UIText.text = "";
	}

}
