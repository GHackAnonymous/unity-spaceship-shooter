using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlMarcador : MonoBehaviour
{
	// Puntos ganados en la partida
	public int puntos = 0;

	// Vidas
	public int vidas = 5;

	// Referencia para el resto de objetos
	public GameObject marcador;
	public GameObject vida;
	// Referencia para las vidas
	public GameObject vida1;
	public GameObject vida2;
	public GameObject vida3;
	public GameObject vida4;
	public GameObject vida5;

	// Actualizar el marcador
	void Update ()
	{
		// Localizamos el componente del UI
		Text t = marcador.GetComponent<Text> ();
		Text v = vida.GetComponent<Text> ();

		// Actualizamos el marcador
		t.text = "Puntos: " + puntos.ToString () + "\n";
		// v.text = "Vidas: " + vidas.ToString () + "\n";
		v.text = "Vidas:";

		// switch VIDAS
		switch (vidas) {
		case 0:
			vida1.SetActive (false);
			// Si el número de vidas llega a 0, GameOver
			Application.LoadLevel (2);
			break;
		case 1:
			vida2.SetActive (false);
			break;
		case 2:
			vida3.SetActive (false);
			break;
		case 3:
			vida4.SetActive (false);
			break;
		case 4:
			vida5.SetActive (false);
			break;
		case 5:
			vida1.SetActive (true);
			vida2.SetActive (true);
			vida3.SetActive (true);
			vida4.SetActive (true);
			vida5.SetActive (true);
			break;
		default:
			vida1.SetActive (true);
			vida2.SetActive (true);
			vida3.SetActive (true);
			vida4.SetActive (true);
			vida5.SetActive (true);
			break;

		}

		// VIDAS EXTRAS cada 2000 puntos una vida extra
		if (puntos>= 2000 ) {
			if ((puntos%2000)==0) {
				vidas = vidas + 1;
			}

		}



	}
}
