using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritScript : MonoBehaviour {

	PolygonCollider2D catbod;

	bool colliding;

	Rigidbody rb;

	public float moveSpeed;
	public bool outOfRange;

	private Vector3 forward;
	private Vector3 right;

	private Vector3 upMove;
	private Vector3 rightMove;

	public GameObject baseCat;

	public float tetherDist;
	public Vector3 initPosition;

	public bool returningToBody;
	public float soulReturnTime;
	private float soulTime = 1f;

	public bool SpiritIsFrozen = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		forward = Camera.main.transform.forward;

		forward.y = 0;

		forward = Vector3.Normalize(forward);

		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

		baseCat = GameObject.Find("CATWALK");
		returningToBody = false;
	}

	// Update is called once per frame
	void Update () {

		initPosition = transform.position;

		Vector3 moveDirection = Vector3.zero;
		if (!SpiritIsFrozen) {
			if (((Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0)) && !returningToBody) {
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

				upMove = forward * moveSpeed * Time.deltaTime * Input.GetAxis ("Vertical");
				rightMove = right * moveSpeed * Time.deltaTime * Input.GetAxis ("Horizontal");

				Vector3 fixedAxis = Vector3.Normalize (rightMove + upMove);
				transform.forward = fixedAxis;

				initPosition += rightMove;
				initPosition += upMove;	

				float tmpDist = Vector3.Distance (baseCat.transform.position, initPosition);
				if (tmpDist <= tetherDist) {

					transform.position += rightMove;
					transform.position += upMove;

				}
	
			}
			
			if (Input.GetKeyDown (KeyCode.R)) {
				soulReturnTime = 0f;
			}
		}
		if (soulReturnTime < soulTime)
		{
			soulReturnTime += Time.deltaTime;

			if (soulReturnTime > soulTime) {
				soulReturnTime = soulTime;
			}

			float progress = soulReturnTime / soulTime;
			transform.position = Vector3.Lerp(transform.position, baseCat.transform.position, progress);
		}

	}
}
