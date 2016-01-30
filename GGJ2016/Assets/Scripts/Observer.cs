using UnityEngine;
using System.Collections;

public class Observer : MonoBehaviour {

	public delegate void ItemActivateAction();
	public static event ItemActivateAction OnItemActivate;


}
