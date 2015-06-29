using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlEscudo : MonoBehaviour
{

	// Puntos ganados en la partida
	public int puntos;

	// variables para el tiempo
	public float tInicio;
	public float tActual;

	// duracion del escudo
	public float tEscudo = 10f; 

	// para controlar los objetos
	public GameObject marcador;
	public GameObject escudo;
	public Animator coraza;

	// estado del escudo
	private bool activo = false;

	// sonido del escudo
	private AudioSource source;
	public	AudioClip Electro;

	// Use this for initialization
	void Start ()
	{
		// estado inicial
		activo = false;
		OffEscudo ();
		coraza = escudo.GetComponent<Animator> ();

		// asigno el sonido del escudo
		source = GetComponent<AudioSource> ();
		source.clip = Electro;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// accedo a la puntuacion 
		puntos = marcador.GetComponent<ControlMarcador> ().puntos;

		// controlo los puntos para activar el escudo
		if (puntos >= 1000) {
			if ((puntos % 1000) == 0) {
				if (!activo) {
					// si el escudo esta desactivado
					source.pitch=3f;
					source.Play ();
					TiempoInicio ();
					activo = true;
					OnEscudo ();
				}
			}
		}
//		 tomo el tiempo actual para calcular el intervalo de tiempo
//		y desactivar el escudo
		tActual = Time.time;

		// controlo el tiempo transcurrido
		if (activo) {
			if (tActual - tInicio < tEscudo) {
				// si no han trancurrido


			} else {
				activo = false;
				OffEscudo ();
				source.Stop ();

			}

		}
	}
	void TiempoInicio ()
	{
		// recogo el tiempo cuando se activa el escudo
		tInicio = Time.time;
	}

	void OnEscudo ()
	{
		escudo.GetComponent<SpriteRenderer> ().enabled = true;
		escudo.GetComponent<CircleCollider2D> ().enabled = true;
	}

	void OffEscudo ()
	{
		escudo.GetComponent<SpriteRenderer> ().enabled = false;
		escudo.GetComponent<CircleCollider2D> ().enabled = false;
	}

}
