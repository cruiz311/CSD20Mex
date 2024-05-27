using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectarCollision : MonoBehaviour
{
    public PlayerSO player;
    public Image EscudoSeleccionado; // Image que se actualizará con el nuevo sprite
    public TextMeshProUGUI estadoName;
    public TextMeshProUGUI sinImportancia;
    private void Start()
    {
        if (CreateNewPlayer.instance.nuevoJugador != null)
        {
            player = CreateNewPlayer.instance.nuevoJugador;
        }
    }
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

            // Comprobar si el objeto tiene el tag "Estado"
            if (hit.collider != null && hit.collider.CompareTag("Estado"))
            {
                string hitName = hit.collider.name;
                Estado estadoSeleccionado = hit.collider.GetComponent<Estado>();
                player.estadoPlayer = estadoSeleccionado.estado;
                estadoName.text = estadoSeleccionado.name;
                EscudoSeleccionado.sprite = estadoSeleccionado.estado.escudoEstado;
                EscudoSeleccionado.gameObject.SetActive(true);
                sinImportancia.gameObject.SetActive(false);
                Debug.Log(hitName);
            }
        }
    }
}
