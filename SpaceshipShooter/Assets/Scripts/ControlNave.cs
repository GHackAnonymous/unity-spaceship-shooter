using UnityEngine;
using System.Collections;

public class ControlNave : MonoBehaviour
{
	public float velocidadNave = 20f;
	public float velocidadDisparo = 10f;

	// Acceso al prefab Disparo
	public Rigidbody2D disparo;

	public GameObject escudo;


	void Start(){

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
		// Izquierda
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector3.left * velocidadNave * Time.deltaTime);
		}

		// Derecha
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right * velocidadNave * Time.deltaTime);
		}

		// Disparo
		if (Input.GetKeyDown (KeyCode.Space)) {
			Disparar ();
		}
	}

}
