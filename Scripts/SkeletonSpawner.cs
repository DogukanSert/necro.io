using UnityEngine;
using System.Collections;

public class SkeletonSpawner : MonoBehaviour {

	public GameObject deadSkeleton;	// Oluşacak ölü iskelet objesi
	public GameObject background;	// Sınırlar için obje
	private float spawnTime = 2;	// Spawnlar arası süre
	private float nextSpawn;
	private float leftBor, rightBor, topBor, botBor;

	void Start () // Sınırları belirliyor 
	{
		leftBor = background.GetComponent<Transform> ().position.x - (background.GetComponent<BoxCollider2D> ().size.x / 2);
		rightBor = background.GetComponent<Transform> ().position.x + (background.GetComponent<BoxCollider2D> ().size.x / 2);
		botBor = background.GetComponent<Transform> ().position.y - (background.GetComponent<BoxCollider2D> ().size.y / 2);
		topBor = background.GetComponent<Transform> ().position.y + (background.GetComponent<BoxCollider2D> ().size.y / 2);
	}

	void Update ()
	{
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnTime;
			Instantiate (deadSkeleton, new Vector2 ( Random.Range (leftBor, rightBor), Random.Range(botBor, topBor)),
				Quaternion.Euler (0, 0, 0));
		}
	}
}
