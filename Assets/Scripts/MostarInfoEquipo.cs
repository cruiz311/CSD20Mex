using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostarInfoEquipo : MonoBehaviour
{
    public TextMeshProUGUI informacionEquipo;
    public Image estadio;
    public TextMeshProUGUI NombreEstadio;
    public Button nextScene;

    public void MostrarInformacionEquipo(EquipoSO equipo)
    {
        caos();
        informacionEquipo.text = equipo.InformacionEquipo;
        estadio.sprite = equipo.SpriteEstadio;
        NombreEstadio.text = equipo.NombreEstadio;
        nextScene.gameObject.SetActive(true);
    }
    public void caos()
    {
        informacionEquipo.enabled = true;
        estadio.enabled = true;
        NombreEstadio.enabled = true;
    }

}
