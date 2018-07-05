using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;    //플레이어의 총체력
    public int currentHealth;           //플레이어의 현재체력

    public float flashSpeed = 5f;       //데미지를 입을 경우 화면을 물들이고 있을 시간

    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);  //데미지를 입을 경우 화면을 물들일 색깔
    public Slider healthSlider; //HealthUI의 Slider객체 추가
    public Image damageImage;   //damage를 받을경우 화면에 출력할 이미지 추가
    public AudioClip deathClip; 

    Animator anim;              //PlayerAnimator 추가
    AudioSource playerAudio;    
    PlayMovement playMovement;  //PlayMovement C# 스크립트 

    bool isDead;            //죽었는지 여부 확인
    bool damaged;           //데미지를 입었는지 현제 상태의 여부 확인

    private void Awake() {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playMovement = GetComponent<PlayMovement>();
        // 위의 GetComponent는 현재 스크립트를 추가한 객체에 포함되있는 요소를 불러오는 효과가 있다

        currentHealth = startingHealth;
    }

    private void Update() {
        damageImage.color= (damaged)? flashColor: Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        
        damaged = false;
    }

    public void TaskDamage(int amount) {
        damaged = true;

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
