using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
	public List<Recogible> inventario = new List<Recogible>();

	public Transform[] posInventario;

	public void AñadirObjeto(Recogible rec)
	{
		inventario.Add(rec);
		rec.transform.position = posInventario[0].position + new Vector3(0,0,-1);
	}

	public bool BuscarObjeto(string nombre) {
		foreach (Recogible rec in inventario)
		{
			if (rec.name == nombre)
			{
				return true;
			}
		}
		return false;
	}
}
