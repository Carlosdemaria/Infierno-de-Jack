using UnityEngine;

public class Interactuable : MonoBehaviour
{
	public string itemClave;
	public Animator anim;

	public void Abrir()
	{
		anim.SetTrigger("Abrir");
	}
}
