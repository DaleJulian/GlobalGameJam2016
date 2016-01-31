using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour {

	private static ToolTipManager _instance;
	
	public static ToolTipManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<ToolTipManager>();
				//DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}
	
	void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			//DontDestroyOnLoad(this);
		}
		else
		{
			if (this != _instance)
				Destroy(this.gameObject);
		}
	}

	public Text UIText;

	private Dictionary<string, string> TextList = new Dictionary<string, string>();

	private float letterPause = 0.08f;

	private string currentlyDisplayedText;

	public void Start() {
		UIText = GetComponent<Text>();
		UIText.text = "";

		TextList.Add("Eye", "I need to find chuvaness eye.");

		//test:
		toggleText("Eye");
		//TODO script
	}

	public void toggleText(string key) {
		if(TextList.ContainsKey(key)) {
			StartCoroutine (TypewriterText(TextList[key].ToString()));
		}
		currentlyDisplayedText = TextList[key].ToString();
	}

	private IEnumerator TypewriterText(string text) {
		foreach (char letter in text.ToCharArray()) {
			UIText.text += letter;	
			yield return new WaitForSeconds(letterPause);
		}
	}

	private IEnumerator TypewriterDelete() {
		foreach (char letter in UIText.text.ToCharArray()) {
			UIText.text = UIText.text.Remove(UIText.text.Length);
			yield return new WaitForSeconds(letterPause);
		}
	}

	public void deleteText() {
		StartCoroutine (TypewriterDelete ());
	}

}
