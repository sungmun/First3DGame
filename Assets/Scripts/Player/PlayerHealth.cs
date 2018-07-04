using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public float flashSpeed = 5f;

    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;

    Animator anim;
    AudioSource playerAudio;
    PlayMovement playMovement;

    bool isDead;
    bool damaged;

    private void Awake() {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playMovement = GetComponent<PlayMovement>();
        currentHealth = startingHealth;
    }

    private void Update() {
        if (damaged) {
            damageImage.color = flashColor;
        } else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
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

    void Death() {
        isDead = true;
        anim.SetTrigger("Die");
        playMovement.enabled = false;
    }

}
