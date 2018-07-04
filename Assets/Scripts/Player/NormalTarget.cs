using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTarget : MonoBehaviour {

    public List<Collider> targetList;

    private void Awake() {
        targetList = new List<Collider>();
    }

    void Update () {
		
	}
}
