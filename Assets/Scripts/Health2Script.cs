using UnityEngine;
using System.Collections;

public class Health2Script : MonoBehaviour {

	public int hp = 5;
	private Player2Controller player; 

	void Awake () {
		player = gameObject.GetComponent<Player2Controller> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		//player = gameObject.GetComponent<PlayerScript>();
		PlayerWeaponScript shot = collider.gameObject.GetComponent<PlayerWeaponScript> ();
		if (shot != null) {			
			hp -= shot.damage;
			if (shot.shotType.Equals ("fire")) {				
				shot.transform.localScale = new Vector3(shot.transform.localScale.x * 2.4f, shot.transform.localScale.y * 2.4f, 1);
				int i = 0;
				while (i < 100)
					i++;

				shot.transform.localScale = new Vector3(shot.transform.localScale.x * 2.4f, shot.transform.localScale.y * 2.4f, 1);
				i = 0;
				while (i < 100)
					i++;

				shot.transform.localScale = new Vector3(shot.transform.localScale.x * 2.4f, shot.transform.localScale.y * 2.4f, 1);
				i = 0;
				while (i < 100)
					i++;

				//shot.transform.localScale = new Vector3(shot.transform.localScale.x * 2.52f, shot.transform.localScale.y * 2.52f, 1);
			}
			//Destroy (shot.gameObject);
			if (hp <= 0) {
				if (player.weapon != null) {
					Destroy (player.weapon);
				}
				Destroy (gameObject);

			}			
		}
	}
}
