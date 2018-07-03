﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;

    Animator anim;
    AudioSource playerAudio;
    PlayMovement playMovement;

    bool isDead;

    private void Awake() {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playMovement = GetComponent<PlayMovement>();
        currentHealth = startingHealth;
    }

    public void TaskDamage(int amount) {
        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead) {
            Death();
        } else {
            anim.SetTrigger("Damage");
        }
    }



    void Start () {
		
	}
	
	void Update () {
		
	}
}
