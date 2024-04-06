using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    float h;
    float v;
    Rigidbody2D rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        h = Input.GetAxisRaw("Horizontal")* 10;
        v = Input.GetAxisRaw("Vertical")*10;
    }

    void FixedUpdate() {
        rigid.velocity = new Vector2(h, v);
    }
}
