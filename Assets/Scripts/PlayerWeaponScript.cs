using UnityEngine;
using System.Collections;

public class PlayerWeaponScript : MonoBehaviour {

	//public Transform shotPrefab;

	//public float shootingRate = 0.25f;

	//private float shootCooldown;

	// ShotScript code
	public PlayerController caster;
	private bool atCaster = false;
	public string shotType = "default";

	public int damage = 1;

	public Vector2 speed = new Vector2 (10, 10);
	public Vector2 direction = new Vector2(1, 0);

	public bool hasShot { get; set; }
	public bool fire = false;

	void Start() {
		//shootCooldown = 0f;
		hasShot = false;
	}

	void Update() {
		//		if (shootCooldown > 0) {
		//			shootCooldown -= Time.deltaTime;
		//		}

		if (!fire) {
			if (caster.faceRight) {
				direction.x = 1;
			} 
			else {
				direction.x = -5;
			}


			float X = caster.transform.position.x - this.transform.position.x;
			float Y = caster.transform.position.y - this.transform.position.y;
			if ((X > 1 || X < -1) || (Y > 1 || Y < -1)) {
				Vector3 movement = new Vector3 ((speed.x / 2) * X, (speed.y / 2) * Y, 0);
				movement *= Time.deltaTime;
				this.transform.Translate (movement);
			} 
			else {
				hasShot = true;
			}
		}
		if (fire) {
			hasShot = false;
			Destroy (gameObject, 10);

			Vector3 movement = new Vector3 (speed.x * direction.x, 0, 0);
			movement *= Time.deltaTime;
			transform.Translate (movement);
			//fire = false;
		}
	}

	public void Attack() {
		if (hasShot) {
			fire = true;
		}
	}

	public bool CanAttack {
		get {
			return hasShot;
		}
	}

	public void MoveToCaster () {
		float X = caster.transform.position.x - this.transform.position.x;
		float Y = caster.transform.position.y - this.transform.position.y;
		Vector3 movement = new Vector3 (speed.x * X, speed.y * Y, 0);
		movement *= Time.deltaTime;
		this.transform.Translate (movement);
	}

	public void Flip() {
		Vector3 weaponScale = transform.localScale;
		weaponScale.x *= -1;
		transform.localScale = weaponScale;
	}
}
