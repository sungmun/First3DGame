﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour {

    protected Animator avatar;

    float lastAttackTime, lastSkillTime, lastDashTime;
    public bool attacking = false;
    public bool dashing = false;

    float h, v;

    void Start() {
        avatar = GetComponent<Animator>();
    }

    public void OnStickChanged(Vector2 stickPos) {
        h = stickPos.x;
        v = stickPos.y;
    }

    void Update() {
        if (!avatar) {
            return;
        }

        float back = 1f;

        if (v < 0f) back = -1f;

        avatar.SetFloat("Speed", (h * h + h * v));

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody) {
            Vector3 speed = rigidbody.velocity;
            speed.x = 4 * h;
            speed.y = 4 * v;

            rigidbody.velocity = speed;
            if (h != 0f && v != 0f) {
                transform.rotation = Quaternion.LookRotation(new Vector3(h, 0f, v));
            }
        }

    }

    public void OnAttackDown() {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack());
    }

    public void OnAttackUp() {
        avatar.SetBool("Combo", false);
        attacking = false;
    }

    IEnumerator StartAttack() {
        if (Time.time - lastAttackTime > 1f) {
            lastAttackTime = Time.time;
            while (attacking) {
                avatar.SetTrigger("AttackStart");
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void OnSkillDown() {
        if (Time.time - lastSkillTime <= 1f) {
            return;
        }

        avatar.SetBool("Skill", true);
        lastSkillTime = Time.time;
    }

    public void OnSkillUp() {
        avatar.SetBool("Skill", false);
    }

    public void OnDashDown() {
        if (Time.time - lastDashTime <= 1f) {
            return;
        }

        lastDashTime = Time.time;
        dashing = true;
        avatar.SetTrigger("Dash");
    }

    public void OnDashUp() {
        dashing = false;
    }
}
