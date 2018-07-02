using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour {

    protected Animation avatar;

    float lastAttackTime, lastSkillTime, lastDashTime;
    public bool attacking = false;
    public bool dashing = false;

	// Use this for initialization
	void Start () {
        avatar = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
