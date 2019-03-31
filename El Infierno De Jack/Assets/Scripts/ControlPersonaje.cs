using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
	public float velocidad;
	public Animator animador;
	public Inventario inventario;
	public SpriteRenderer sprRenderer;

	public List<Recogible> recogiblesCercanos = new List<Recogible>();
	public List<Interactuable> interactuablesCercanos = new List<Interactuable>();

	void Update()
	{
		if (Input.GetKey(KeyCode.E)){
			Interactuar();
		}

		if (Input.GetKey(KeyCode.F)){
			Recoger();
		}

		if (Input.GetAxis("Horizontal") < 0f)
		{
			Mover(Vector3.left);
			sprRenderer.flipX = false;
		}
		if (Input.GetAxis("Horizontal") > 0f)
		{
			Mover(Vector3.right);
			sprRenderer.flipX = true;
		}
		if (Input.GetAxis("Vertical") > 0f)
		{
			Mover(Vector3.forward);

		}
		if (Input.GetAxis("Vertical") < 0f)
		{
			Mover(Vector3.back);
		}

		if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f) //si no estoy moviendo
		{
			animador.SetBool("Moviendo", false);
		}
	}

	void Mover(Vector3 direccion)
	{
		transform.position += direccion * velocidad * Time.deltaTime;
		animador.SetBool("Moviendo", true);
	}

	void Interactuar() {
		if (interactuablesCercanos.Count != 0)
		{
			if (inventario.BuscarObjeto(interactuablesCercanos[0].itemClave)) //buscar en inventario un objeto con el nombre que pide el interactuable
			{
				interactuablesCercanos[0].Abrir();
			}
		}
	}

	void Recoger() {
		if (recogiblesCercanos.Count != 0)
		{
			inventario.AñadirObjeto(recogiblesCercanos[0]);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.GetComponentInChildren<Recogible>() != null)
		{
			recogiblesCercanos.Add(col.GetComponent<Recogible>());
		}

		if (col.GetComponentInChildren<Interactuable>() != null)
		{
			interactuablesCercanos.Add(col.GetComponent<Interactuable>());
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.GetComponentInChildren<Recogible>() != null)
		{
			recogiblesCercanos.Remove(col.GetComponent<Recogible>());
		}

		if (col.GetComponentInChildren<Interactuable>() != null)
		{
			interactuablesCercanos.Remove(col.GetComponent<Interactuable>());
		}
	}
}
