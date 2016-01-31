using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour {

	public Text UIText;

	private Dictionary<string, string> TextList = new Dictionary<string, string>();

	private float letterPause = 0.08f;

	public void Start() {
		UIText = GetComponent<Text>();
		UIText.text = "";

		TextList.Add("Eye", "I need to find chuvaness eye.");

	
		//TODO script
	}

	public void toggleText(string key) {
		if(TextList.ContainsKey(key)) {
			StartCoroutine (TypewriterText(TextList[key].ToString()));
		}
	}

	public IEnumerator TypewriterText(string text) {
		foreach (char letter in text.ToCharArray()) {
			UIText.text += letter;	
			yield return new WaitForSeconds(letterPause);
		}
	}

	public void turnOffText() {
		UIText.text = "";
	}

}
