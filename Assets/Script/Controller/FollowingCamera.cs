﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {

    public float distanceAway = 7f;
    public float distanceUp = 4f;

    public Transform follow;
    
	void LateUpdate () {
        transform.position = follow.position + Vector3.up * distanceUp - Vector3.forward * distanceAway;
	}
}
