using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviourSingleton<AnimationScript>
{
    public bool s = false;
    public bool t = false;

    public bool right = false;
    public bool left = true;
    public Rigidbody2D rb;

    public GameObject yellowBlob;

    Vector2 v1 = new Vector2(1, 0);
    Vector2 v2 = new Vector2(-1, 0);

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// UpdateAnimation is called once per frame
	public void UpdateAnimation () {
        //rb.velocity = new Vector2(3, rb.velocity.y);

        if (s == true) {
            LeanTween.pause(yellowBlob);
            rb.velocity = new Vector2(rb.velocity.x, 7);
            s = false;
        } else if(t == true){
            /*
            if (left == true) {
                rb.velocity = new Vector2(2, rb.velocity.y);
                right = true;
                left = false;
            } else if (right == true) {
                rb.velocity = new Vector2(-2, rb.velocity.y);
                left = true;
                right = false;
            }
            t = false;
            **/
            LeanTween.moveX(yellowBlob, 10, 0.1f).setLoopPingPong(4);
            
        }
        
	}
}
