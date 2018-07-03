using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public float flashSpeed = 5f;
    public float sinkSpeed = 1f;

    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    bool isDead;
    bool isSinking;
    bool damaged;

    void Start () {
		
	}
	
	void Update () {
		
	}
}
