using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float Speed = 10.0f;
    public float m_JumpSpeed = 0.2f;
    public LayerMask GroundLayers;

    private Transform m_GroundCheck;
    

    void Start () {
        m_GroundCheck = transform.FindChild("GroundCheck");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float hSpeed = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump")){
            bool isGrounded = Physics2D.OverlapPoint(m_GroundCheck.position);
            if (isGrounded){
                rigidbody2D.AddForce(Vector2.up * m_JumpSpeed, ForceMode2D.Impulse);
            }

        }
        this.rigidbody2D.velocity = new Vector2(hSpeed * Speed, this.rigidbody2D.velocity.y);
        	    
	}
}
