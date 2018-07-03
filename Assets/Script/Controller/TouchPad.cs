using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPad : MonoBehaviour {

    private int touchId = -1;
    private bool buttonPressed = false;

    private RectTransform touchPad;
    private Vector3 startPos = Vector3.zero;

    public float dragRadius = 60f;
    public PlayMovement player;

	void Start () {
        touchPad = GetComponent<RectTransform>();
        startPos = touchPad.position;
	}
	
	void Update () {
		
	}
}
