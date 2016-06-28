using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
    public float smoothness = 1.0f;

    private Transform player;

    private float mapX = 60.0f, mapY = 30.0f,
                  minX, maxX, minY, maxY;

	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;

        transform.position = player.position;
        transform.position += Vector3.back;
	}
	
	void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, smoothness * Time.fixedDeltaTime) + Vector3.back;
	}

    void LateUpdate()
    {
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.y = Mathf.Clamp(v3.y, minY, maxY);
        transform.position = v3;
    }
}
