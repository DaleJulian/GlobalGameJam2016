﻿using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void CanObtainAction();
	public static event CanObtainAction OnCanObtain;	


}
