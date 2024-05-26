using UnityEngine;
using TMPro;
public class DetectarCollision : MonoBehaviour
{
    public TextMeshProUGUI texto;
    void Update()
    {
        // Detectar toque en la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Obtener posición del toque
            Vector2 touchPosition = Input.GetTouch(0).position;

            // Convertir posición de pantalla a rayo en el mundo
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touchPosition);

            // Comprobar si el rayo colisiona con un objeto 2D
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            // Comprobar si el objeto tiene el tag "objeto"
            if (hit.collider != null && hit.collider.CompareTag("Estado"))
            {
                texto.text = hit.collider.name;
                // Imprimir mensaje en la consola
                Debug.Log(hit.collider.name);
            }
        }
    }
}
