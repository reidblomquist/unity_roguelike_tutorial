using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	public float moveTime = .1f;
	public LayerMask blockingLayer;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;

	// Use this for initialization
	// Protected virtual functions can be overriden by their inheriting classes
	// This is useful if potentially we want one of the inheriting classes to have a different implimentation of Start()
	protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
		rb2D = GetComponent<Rigidbody2D>();
		// Storing recriprocal of moveTime, we can use it by multiplying instead of dividing
		// this is more efficient computationally
		inverseMoveTime = 1f / moveTime;
	}
	
	protected IEnumerator SmoothMovement (Vector3 end) {
		// Using square magnitude because it is computationally cheaper than Magnitude
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
		
		while (sqrRemainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
