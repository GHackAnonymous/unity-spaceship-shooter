using UnityEngine;
using System.Collections;

public class SalirOnClick : MonoBehaviour
{
	public AudioClip Bocina;
	private AudioSource source;

	public void SalirJuego ()
	{

		source = GetComponent<AudioSource> ();
		source.clip = Bocina;
		source.Play ();
		// quit no hace efecto ni en el editor ni en el WebPlayer
		Application.Quit ();
	}
}
