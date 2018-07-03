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
	
    public void ButtonDown() {
        buttonPressed = true;
    }

    public void ButtonUp() {
        buttonPressed = false;
        HandleInput(startPos);
    }

    void HandleInput(Vector3 input) {
        if (buttonPressed) {
            Vector3 diffVector = (input - startPos);
            if (diffVector.sqrMagnitude > dragRadius * dragRadius) {
                diffVector.Normalize();
                touchPad.position = startPos + diffVector * dragRadius;
            } else {
                touchPad.position = input;
            }

        } else {
            touchPad.position = startPos;
        }


        if (player == null) {
            return;
        }

        Vector3 diff = touchPad.position - startPos;
        Vector2 normDiff = new Vector3(diff.x / dragRadius, diff.y / dragRadius);
        player.OnStickChanged(normDiff);
        
    }

    void Update () {
		
	}
}
