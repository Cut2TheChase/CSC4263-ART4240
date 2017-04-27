///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the GUI element that represents the collection of memory items.
///Author -- Mitchell Aucoin, Jonathan Nguyen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameInit : MonoBehaviour {

	private GameObject player; //finds the player game object
	PlayerHealth playerHealth; //used to call playerHealth.cs
	float disFromPlayer; //distance the player is from the enemy
	public float range; //range at which the enemy will spot the character
	public UnityEngine.UI.Text memoryUI; //the text overlay that is displayed for a specific memory instance
	bool detected = false;  //marks whether memory has been picked up yet, to avoid repeated countMem calls

	//finds player object and its health and movement components
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
	}
	//calculates distance from memory item to player object and calls countMem if the two are close enough
	void Update()
	{
		disFromPlayer = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y),
			new Vector2(transform.position.x, transform.position.y));
		if (disFromPlayer < range && detected == false)
		{
			detected = true;
			StartCoroutine(countMem());
		}
	}
	//used to access the PlayerHealth.cs function memCount(), plays corresponding cutscene, and destroys memory item on contact
	public IEnumerator countMem()
	{
		int counter = 3;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		memoryUI.gameObject.SetActive(true);
		bool done = false;
		Time.timeScale = 0;
		while (done == false)
		{
			yield return null;
			while (!Input.GetKey(KeyCode.E))
			{
				if (counter == 1) {
					GameObject.FindGameObjectWithTag ("Fader").GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 1);
					GameObject.FindGameObjectWithTag ("Sound").GetComponent<AudioSource> ().Stop ();
				}
				memoryUI.gameObject.SetActive(true);
				yield return null;
				if (Input.GetKey(KeyCode.E) && memoryUI.GetComponent<nextText>().next != null)
				{
					memoryUI.gameObject.SetActive(false);
					memoryUI = memoryUI.GetComponent<nextText>().next;
					counter--;
				}
				else if (Input.GetKey(KeyCode.E))
					done = true;
			}
			if (done == true)
			{
				/*Time.timeScale = 1;
				memoryUI.gameObject.SetActive(false);
				playerHealth.memCount();
				Destroy(gameObject);*/
				SceneLoader.instance.LoadScene (6);

			}
		}
	}
}
