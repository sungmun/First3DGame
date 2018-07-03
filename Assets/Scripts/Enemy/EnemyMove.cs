﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Update () {
        if (nav.enabled) {
            nav.SetDestination(player.position);
        }
	}
}
