using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class DestroyForTime:MonoBehaviour
{
    public float time = 1;
    void Start() {
        Invoke("Destroy", time);
    }
    void Destroy() {
        GameObject.DestroyImmediate(this.gameObject);
    }
}

