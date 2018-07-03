using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPad : MonoBehaviour {

    private int touchId = -1;
    private bool buttonPressed = false;

    private RectTransform touchpad;
    private Vector3 startPos = Vector3.zero;

    public float dragRadius = 60f;
    public PlayMovement player;

	void Start () {
		
	}
	
	void Update () {
		
	}
}
