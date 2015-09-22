using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private Rigidbody2D rBody ;
	Animator anim ;
	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D> () ;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ;
		
		if (movementVector != Vector2.zero) {
			anim.SetBool("IsWalking",true) ;
			anim.SetFloat ("InputX", movementVector.x) ;
			anim.SetFloat ("InputY", movementVector.y) ;
		} else {
			anim.SetBool("IsWalking",false) ;
		}
		
		rBody.MovePosition(rBody.position + movementVector * Time.deltaTime) ;	 
	
	}
}
