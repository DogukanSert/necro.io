using UnityEngine;
using System.Collections;

public class Necromancer : MonoBehaviour
{
    RaycastHit2D hit;
    Ray2D ray;
    Vector3 newPosition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse[2] = 0;

            hit = Physics2D.Raycast(mouse, Vector2.zero);

            if (hit.collider.CompareTag("Floor"))
            {

                Vector3 difference = mouse - transform.position;
                transform.Translate(difference * Time.fixedDeltaTime);
                //transform.Translate(origin * Time.fixedDeltaTime);
            }
        }
	}
}
