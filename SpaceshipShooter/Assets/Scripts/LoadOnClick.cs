using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour
{

	public void LoadScene (int level)
	{
		// carga la escena 'level'
		Application.LoadLevel (level);

	}
}
