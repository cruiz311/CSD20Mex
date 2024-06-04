using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Plataforma : MonoBehaviour
{
    public UnityEvent equipoChoseEvent;
    public Button button;
    public EquipoSO EquipoInfo;
    public Image logo;
    public TextMeshProUGUI NombreEquipo;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
        equipoChoseEvent.AddListener(ShowTeamInfo);
        equipoChoseEvent.AddListener(TeamSelectInfo);
    }

    private void ShowTeamInfo()
    {
        MostarInfoEquipo mostrarInfoEquipo = FindObjectOfType<MostarInfoEquipo>();
        mostrarInfoEquipo.MostrarInformacionEquipo(EquipoInfo);
    }

    private void TeamSelectInfo()
    {
        TeamSelect teamSelect = FindAnyObjectByType<TeamSelect>();
        teamSelect.EquipoSeleccionado(EquipoInfo);
    }

    public void ConfigurarPlataforma(EquipoSO equipo)
    {
        EquipoInfo = equipo;
        logo.sprite = equipo.LogoEquipo;
        NombreEquipo.text = equipo.name;
    }

    private void OnButtonClicked()
    {
        equipoChoseEvent?.Invoke();
    }
}
