using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 5;
	private PlayerController player; 
	private AudioSource audio;
	public AudioClip DeathScreamWhenYouDie;

	void Awake () {
		player = gameObject.GetComponent<PlayerController> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		//player = gameObject.GetComponent<PlayerScript>();
		Player2WeaponScript shot = collider.gameObject.GetComponent<Player2WeaponScript> ();
		if (shot != null) {			
			hp -= shot.damage;
			Destroy (shot.gameObject);
			if (hp <= 0) {
				if (player.weapon != null) {
					Destroy (player.weapon);
				}
				Destroy (gameObject);
			}			
		}
	}
}
