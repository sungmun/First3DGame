﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTarget : MonoBehaviour {

    public List<Collider> targetList;

    private void Awake() {
        targetList = new List<Collider>();
    }
}
