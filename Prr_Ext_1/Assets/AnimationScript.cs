using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviourSingleton<AnimationScript>
{
    public bool s = false;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	public void Update () {
        //rb.velocity = new Vector2(3, rb.velocity.y);

        if (s == true) {
            rb.velocity = new Vector2(rb.velocity.x, 5);
            s = false;
        }
	}
}
