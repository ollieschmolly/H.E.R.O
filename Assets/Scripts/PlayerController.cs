using UnityEngine;
using System.Collections;
using Prime31;

public class PlayerController : MonoBehaviour {
	
	public float walkSpeed = 3;
	public float gravity = -35;
	public float jumpHeight = 2;

	private CharacterController2D _controller;
	private AnimationController2D _animator;
	private AudioSource audio;
	public AudioClip DeathScreamWhenYouDie;
	public ArrayList fountains = new ArrayList();
	public bool inFountain = false;
	public PlayerWeaponScript weapon;
	private bool holdingWeapon = false;
	public Vector2 speed = new Vector2(50,50);
	public string name;
	public bool faceRight = false;

	// Use this for initialization
	void Start () {

		_controller = gameObject.GetComponent<CharacterController2D>();
		_animator = gameObject.GetComponent<AnimationController2D>();
	}

	void Awake () {

		//weapons = GetComponentsInChildren<WeaponScript> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 velocity = _controller.velocity;

		if (Input.GetAxis ("Horizontal_P1") < 0) {
			velocity.x = -walkSpeed;
			if (_controller.isGrounded != true) {
				_animator.setAnimation ("Jump");
			}
			else {
				_animator.setAnimation ("Cyborg");
			}
			_animator.setFacing ("Left");
			faceRight = false;
		} 

		else if (Input.GetAxis ("Horizontal_P1") > 0) {
			velocity.x = walkSpeed;
			if (_controller.isGrounded != true) {
				_animator.setAnimation ("Jump");
			}
			else {
				_animator.setAnimation ("Cyborg");
			}
			_animator.setFacing ("Right");
			faceRight = true;
		}

		else if (_controller.isGrounded != true) {
			_animator.setAnimation ("Jump");
		}

		else {
			_animator.setAnimation ("Idle");
		}
			
		if (Input.GetAxis ("Jump_P1") > 0 && _controller.isGrounded) {
			velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);

		}
		if (weapon == null)
			holdingWeapon = false;
		float inputX = Input.GetAxis ("Horizontal_P1");
		float inputY = Input.GetAxis ("Vertical_P1");

		bool shoot = Input.GetButtonDown ("Shoot_P1");
		bool grab = Input.GetButtonDown ("Grab_P1");

		if (shoot) {
			if (weapon != null && weapon.CanAttack) {
				holdingWeapon = false;
				weapon.Attack ();
			}
		}
		if (grab && inFountain && !holdingWeapon) {
			FountainScript fountain = (FountainScript) fountains [0];
			fountain.CreateShot(this);
			holdingWeapon = true;
		}

		velocity.x *= 0.85f;

		velocity.y += gravity * Time.deltaTime;

		_controller.move(velocity * Time.deltaTime);
	}
	void Flip() {
		// Switch the way the player is labelled as facing.

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "KillZ") {
			audio = gameObject.GetComponent<AudioSource> ();
			try {
				Destroy (weapon);
			}
			catch (MissingReferenceException e) {}
			audio.PlayOneShot (DeathScreamWhenYouDie, 1f);
			Destroy (gameObject,2);

		}
	}
}