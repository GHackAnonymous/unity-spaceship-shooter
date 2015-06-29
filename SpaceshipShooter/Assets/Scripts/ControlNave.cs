using UnityEngine;
using System.Collections;

public class ControlNave : MonoBehaviour
{
	public float velocidadNave = 20f;
	public float velocidadDisparo = 10f;

	// para delimitar la escena
	public float limiteI;
	public float limiteD;
	public float horizonte;

	// Acceso al prefab Disparo
	public Rigidbody2D disparo;
	public GameObject escudo;

	void Start ()
	{

	}
	
	// Hacemos copias del prefab del disparo y las lanzamos
	void Disparar ()
	{
		// Clonar el objeto
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;

		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 3f);

		// Lanzarlo
		d.AddForce (Vector2.up * velocidadDisparo);	
	}

	void Update ()
	{
		horizonte = Camera.main.orthographicSize * Screen.width / Screen.height;
		// Izquierda
		limiteI = (horizonte * -1) + 1;
		limiteD = (horizonte) - 1;

		// Izquierda
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (transform.position.x >= limiteI) {
				transform.Translate (Vector3.left * velocidadNave * Time.deltaTime);
			} else {
				transform.Translate (Vector3.left * velocidadNave * Time.deltaTime * 0);
			}
		}

		// Derecha
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (transform.position.x <= limiteD) {
				transform.Translate (Vector3.right * velocidadNave * Time.deltaTime);
			} else {
				transform.Translate (Vector3.right * velocidadNave * Time.deltaTime * 0);
			}
		}


		// Disparo
		if (Input.GetKeyDown (KeyCode.Space)) {
			Disparar ();
		}
	}

}
