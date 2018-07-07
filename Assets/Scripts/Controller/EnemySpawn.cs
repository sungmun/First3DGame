using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;            //복사를 할 게임오브젝트
    public float intervalTime = 10f;    //복사 주기
    public Transform[] spawnPools;      //복사를 한 게임오브젝트를 배치할 위치목록

	void Start () {
        InvokeRepeating("Spawn", intervalTime, intervalTime);
        //2번째 인자값 초에 Spawn메소드를 호출하고 3번째 인자값 초마다 Spawn메소드를 호출한다
	}
	
    void Spawn() {
        int spawnPoolIndex = Random.Range(0, spawnPools.Length); //0부터 spawnPools.Length까지의 값중에 랜덤한 값을 호출
        Instantiate(enemy, spawnPools[spawnPoolIndex].position, spawnPools[spawnPoolIndex].rotation);
        //Instantiate는 유니티에 오브젝트를 추가를 해주는 메소드이다.
        //첫번째 인자값은 추가를 할 오브젝트이며, 두번째 인자값은 추가할 오브젝트의 위치, 세번째 인자값은 추가할 오브젝트의 회전정도를 나타낸다.
    }
}
