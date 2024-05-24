using UnityEngine;

public class DetectarCollision : MonoBehaviour
{
    void Update()
    {
        // Detectar toque en la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Obtener posición del toque
            Vector2 touchPosition = Input.GetTouch(0).position;

            // Convertir posición de pantalla a rayo en el mundo
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            // Comprobar si el rayo colisiona con un objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Comprobar si el objeto tiene el tag "objeto"
                if (hit.collider.CompareTag("objeto"))
                {
                    // Imprimir mensaje en la consola
                    Debug.Log(hit.collider.name);
                }
            }
        }
    }
}
