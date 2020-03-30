using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public float speed;
    public static bool moveEnabled;
    private float horizontal;
    private float vertical;

    void Start(){

        moveEnabled = true;

    }

    void Update(){

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate(){

        if(moveEnabled){

            Move();

        }

    }

    private void Move(){

            Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
            GetComponent<Rigidbody2D>().MovePosition((Vector2) transform.position + (moveDirection * speed));

    }

}
