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
        player.OnStickChanged(new Vector3(diff.x / dragRadius, diff.y / dragRadius));
        
    }
    void FixedUpdate() {
        HandleTouchInput();
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER
        HandleInput(Input.mousePosition);
#endif
    }

    void HandleTouchInput() {
        int i = 0;
        if (Input.touchCount <= 0) {
            return;
        }
        
        foreach(Touch touch in Input.touches) {
            i++;
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y);
            if (touch.phase == TouchPhase.Began) {
                if (touch.position.x <= (startPos.x + dragRadius)) {
                    touchId = i;
                }
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
                if (touchId == i) {
                    HandleInput(touchPos);
                }
            }

            if (touch.phase == TouchPhase.Ended) {
                if (touchId == i) {
                    touchId = -1;
                }
            }
        }
        
    }

}
