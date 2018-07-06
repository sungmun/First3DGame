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
        //데미지를 입은 즉시 빨간 화면으로 전환
        //그후 빨간 화면에서 서서히 투명한 이미지로 전환
        //Color.Lerp메소드를 통해 색이 서서히 변경이 가능하다.
        //Color.Lerp메소드는 두개의 색을 섞어주는 역활을 하며, 3번째 인자값으로 두개의 값중 어떤색쪽으로 더 치중해서 색을 표현할지를 정한다.
        //또한 인자값은 0 ~ 1 사이에 있어야 한다.
        damaged = false; 
        
    }
    /*
     * 데미지를 입을 경우 호출이 되는 메소드이다
     */
    public void TaskDamage(int amount) {

        damaged = true;     //데미지를 입었다는 사실을 Update에 알려주기 위한 부분

        currentHealth -= amount;    //입은 데미지를 현재 체력에서 빼주는 부분

        healthSlider.value = currentHealth; //현재 체력을 Silber에 반영해줌

        if (currentHealth <= 0 && !isDead) {        //현재 체력이 0보다 작거나 같으면서 죽은 상태가 아니일때,
            Death();                                //Death 메소드 실행
        } else {
            anim.SetTrigger("Damage");              //위의 경우가 아니인경우 애니메이션에 데미지 트리거를 전달
        }
    }

    void Death() {
        isDead = true;                  
        anim.SetTrigger("Die");         
        playMovement.enabled = false;
    }

}
