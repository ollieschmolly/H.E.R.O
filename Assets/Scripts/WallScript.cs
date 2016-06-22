using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		PlayerWeaponScript shot = collider.gameObject.GetComponent<PlayerWeaponScript> ();
		Player2WeaponScript enemyShot = collider.gameObject.GetComponent<Player2WeaponScript> ();
		if (shot != null && shot.fire) {			
			Destroy (shot.gameObject);
		}
		if (enemyShot != null && enemyShot.fire) {
			Destroy (enemyShot.gameObject);
		}
	}
}
