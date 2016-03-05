using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody g_Rigidbody;
	private int counter;
	public float speed;
	public Text counterText;
	
	// Use this for initialization
	void Start () {
		g_Rigidbody = GetComponent<Rigidbody> ();
		counter = 0;
		updateText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal , 0, moveVertical);
		g_Rigidbody.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other)
	{
		/* Destroy(other.gameObject);		//Removes de component and childs from scene */
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			counter = counter + 1;
			updateText ();
		}
	}
	void updateText()
	{
		counterText.text = "Counter: " + counter.ToString ();
	}
}