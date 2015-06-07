using UnityEngine;
using System.Collections;

//[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class TouchControls : MonoBehaviour {

	//texturas
	public GUITexture izquierda;
	public GUITexture derecha;
	public GUITexture tiro;

	//disparo
	public Rigidbody2D disparo;

	// variables del movimiento
	public float velocidadNave = 20f;
	public float velocidadDisparo = 10f;

	// estados de movimiento
	private bool moveLeft, moveRight, dispara = false;

	// para delimitar la escena
	public float limiteI;
	public float limiteD;
	public float horizonte;

	// Use this for initialization
	void Start () {
	
	}

	//
	void Disparar(){
		// Clonar el objeto
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);
		
		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;
		
		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 3f);
		
		// Lanzarlo
		d.AddForce (Vector2.up * velocidadDisparo);	
		

	}
	
	// Update is called once per frame
	void Update () {

		horizonte = Camera.main.orthographicSize * Screen.width / Screen.height;
		
		limiteI = (horizonte * -1) + 1;
		limiteD = (horizonte) - 1;

		// Check to see if the screen is being touched
		if (Input.touchCount > 0)
		{
			// Get the touch info
			Touch t = Input.GetTouch(0);
			
			// Did the touch action just begin?
			if (t.phase == TouchPhase.Began)
			{
				// Are we touching the left arrow?
				if (izquierda.HitTest(t.position, Camera.main))
				{
					Debug.Log("Touching Left Control");
					moveLeft = true;
				}
				
				// Are we touching the right arrow?
				if (derecha.HitTest(t.position, Camera.main))
				{
					Debug.Log("Touching Right Control");
					moveRight = true;
				}
				
				// Are we touching the jump button?
				if (tiro.HitTest(t.position, Camera.main))
				{
					Debug.Log("Touching disparo");
					dispara = true;
				}
			}
			
			// Did the touch end?
			if (t.phase == TouchPhase.Ended)
			{
				// Stop all movement
				dispara = moveLeft = moveRight = false;
				transform.Translate (Vector3.left * velocidadNave * Time.deltaTime * 0);


			}
		}

		// Is the left mouse button down?
		if (Input.GetMouseButtonDown(0))
		{
			// Are we clicking the left arrow?
			if (izquierda.HitTest(Input.mousePosition, Camera.main))
			{
				Debug.Log("Touching Left Control");
				moveLeft = true;
			}
			
			// Are we clicking the right arrow?
			if (derecha.HitTest(Input.mousePosition, Camera.main))
			{
				Debug.Log("Touching Right Control");
				moveRight = true;
			}
			
			// Are we clicking the jump button?
			if (tiro.HitTest(Input.mousePosition, Camera.main))
			{
				Debug.Log("Touching Jump Control");
				dispara = true;
			}
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			// Stop all movement on left mouse button up
			dispara = moveLeft = moveRight = false;
			transform.Translate (Vector3.left * velocidadNave * Time.deltaTime * 0);

		//rigidbody2D.velocity = Vector2.zero;
		}
	}
	
	void FixedUpdate()
	{
		// Set velocity based on our movement flags.
		if (moveLeft)
		{
			if (transform.position.x >= limiteI) {
				transform.Translate (Vector3.left * velocidadNave * Time.deltaTime);
			} else {
				transform.Translate (Vector3.left * velocidadNave * Time.deltaTime * 0);
			}
		}
		
		if (moveRight)
		{
			if (transform.position.x <= limiteD) {
				transform.Translate (Vector3.right * velocidadNave * Time.deltaTime);
			} else {
				transform.Translate (Vector3.right * velocidadNave * Time.deltaTime * 0);
			}		}
		
		if (dispara)
		{
			Disparar();
				dispara = false;

		}


	}
}
