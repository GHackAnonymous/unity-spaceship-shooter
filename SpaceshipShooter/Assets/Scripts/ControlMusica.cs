using UnityEngine;
using System.Collections;

public class ControlMusica : MonoBehaviour
{

	public GameObject marcador;
	private AudioSource source;
	private int vida;

	// Localizo el sonido para marcar la velocidad inicial
	void Awake ()
	{
		source = GetComponent<AudioSource> ();
		source.pitch = 0.80f;
	}
	// localizo el marcador para poder acceder al numero de vidas restantes
	void Start ()
	{
		marcador = GameObject.Find ("Marcador");
	}
	// Update is called once per frame
	void Update ()
	{
		vida = marcador.GetComponent<ControlMarcador> ().vidas;

		// switch para acelerar la musica al restar vidas
		switch (vida) {
		case 1:
			source.pitch = 1.2f;
			break;
		case 2:
			source.pitch = 1.02f;
			break;
		case 3:
			source.pitch = 1.00f;
			break;
		case 4:
			source.pitch = 0.97f;
			break;
		case 5:
			source.pitch = 0.90f;
			break;
		}
	}
}
