﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public float flashSpeed = 5f;
    public float sinkSpeed = 1f;

    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    bool isDead;
    bool isSinking;
    bool damaged;

    private void Awake() {
        currentHealth = startingHealth;
    }
    void Death() {
        isDead = true;

        transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;

        StartSinking();
    }
    public void StartSinking() {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }
	void Update () {
		
	}
}
