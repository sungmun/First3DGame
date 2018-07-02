using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour {

    protected Animator avatar;

    float lastAttackTime, lastSkillTime, lastDashTime;
    public bool attacking = false;
    public bool dashing = false;

    float h, v;
	
	void Start () {
        avatar = GetComponent<Animator>();
	}

    public void OnStickChanged(Vector2 stickPos){
        h = stickPos.x;
        v = stickPos.y;
    }
	
	void Update () {
        if (avatar) {
            float back = 1f;

            if (v < 0f) back = -1f;

            avatar.SetFloat("Speed", (h * h + h * v));

            Rigidbody rigidbody = GetComponent<Rigidbody>();
            if (rigidbody) {
                Vector3 speed = rigidbody.velocity;
                speed.x = 4 * h;
                speed.y = 4 * v;

                rigidbody.velocity = speed;
                if(h!=0f && v != 0f) {
                    transform.rotation = Quaternion.LookRotation(new Vector3(h, 0f, v));
                }
            }
        }
	}

}
