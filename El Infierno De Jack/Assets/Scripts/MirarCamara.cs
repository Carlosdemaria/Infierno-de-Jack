using UnityEngine;

public class MirarCamara : MonoBehaviour
{

    void Update()
    {
		Vector3 direccion = transform.position + Camera.main.transform.rotation * Vector3.back;
		direccion.y = transform.position.y;
		transform.LookAt(direccion, Vector3.up);
	}
}
