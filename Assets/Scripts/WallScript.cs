using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		PlayerWeaponScript shot = collider.gameObject.GetComponent<PlayerWeaponScript> ();
		ShurikenScript enemyShot = collider.gameObject.GetComponent<ShurikenScript> ();
		if (shot != null) {			
			Destroy (shot.gameObject);
		}
		if (enemyShot != null) {
			Destroy (enemyShot.gameObject);
		}
	}
}
