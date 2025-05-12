using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public float Movespeed = 3.5f;
  
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * Movespeed * Time.deltaTime);
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("wallend") == true)
        {
            Destroy(this.gameObject);
        }
	}
}
