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
	public float tEscudo = 8f; // duracion del escudo
	public GameObject marcador;
	public GameObject escudo;

	// estado del escudo
	private bool activo=false;
	// sonido del ecudo
	private AudioSource source;
	public	AudioClip Electro;

	// Use this for initialization
	void Start ()
	{
		// estado inicial
		activo = false;
		escudo.GetComponent<SpriteRenderer> ().enabled = false;
		escudo.GetComponent<Collider2D> ().enabled = false;
		//
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
					source.Play();
					TiempoInicio ();
					activo = true;
					escudo.GetComponent<SpriteRenderer> ().enabled = true;
					escudo.GetComponent<Collider2D> ().enabled = true;
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
//				escudo.GetComponent<SpriteRenderer> ().enabled = true;
//				escudo.GetComponent<Collider2D> ().enabled = true;
			} else {
				activo = false;
				escudo.GetComponent<SpriteRenderer> ().enabled = false;
				escudo.GetComponent<CircleCollider2D> ().enabled = false;
				FinEscudo();
				source.Stop();
			}

		}
	}
	void TiempoInicio ()
	{

		tInicio = Time.time;
	}
	void FinEscudo(){
		GetComponent<Animation> ().enabled = false;

	}
}
