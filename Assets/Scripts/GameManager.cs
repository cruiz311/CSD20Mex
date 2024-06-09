using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public enum Formacion
{
    F4_3_3,
    F4_4_2,
    F4_2_3_1
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Create a new GameObject to attach the singleton instance if it doesn't exist
                GameObject singletonObject = new GameObject();
                _instance = singletonObject.AddComponent<GameManager>();
                singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";

                // Optionally, make the singleton persistent across scenes
                DontDestroyOnLoad(singletonObject);
            }
            return _instance;
        }
    }
    [Header("Controlador")]
    public GameSO game;
    [Header("EquipoLocal")]
    public Image imagenClub;
    [Header("EquipoVisitante")]
    public EquipoSO equipoRival;
    public Image equipoRivalImagen;
    public TextMeshProUGUI NombreRival;
    [Header("Calendario")]
    public CalendarioSO calendarioSO;
    [Header("Alineacion")]
    public Formacion formacion = Formacion.F4_3_3;
    public Image formacionImage;
    public Sprite[] alineacion;
    public TextMeshProUGUI alineacionNombre;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            // Optionally, make the singleton persistent across scenes
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            // Destroy the duplicate instance
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        imagenClub.sprite = game.equipoSeleccionado.LogoEquipo;
        game.SemanaActual = ObtenerSemana(calendarioSO.semanaActual);

        Partido partido = BuscarPartidoDeEquipo(game.equipoSeleccionado, game.SemanaActual);
        if (partido.local == game.equipoSeleccionado)
        {
            equipoRival = partido.visita;
            equipoRivalImagen.sprite = equipoRival.LogoEquipo;
            NombreRival.text = equipoRival.name;
        }
        else
        {
            equipoRival = partido.local;
            equipoRivalImagen.sprite = equipoRival.LogoEquipo;
            NombreRival.text = equipoRival.name;
        }
        if(formacionImage!= null)
        {
            CambiarAlineacion();
        }
        
    }

    public Semana ObtenerSemana(int numeroSemana)
    {
        foreach (Semana semana in calendarioSO.semanas)
        {
            if (semana.numeroSemana == "Semana " + numeroSemana)
            {
                return semana;
            }
        }
        return null; // O puedes lanzar una excepción si prefieres manejar el caso en que la semana no se encuentre
    }

    public Partido BuscarPartidoDeEquipo(EquipoSO equipo, Semana semana)
    {
        foreach (Partido partido in semana.FechaDePartidos)
        {
            if (partido.local == equipo || partido.visita == equipo)
            {
                return partido;
            }
        }
        return null;
    }

    public void siguienteSemana()
    {
        calendarioSO.SiguienteSemana();
    }

    public void CambiarAlineacion()
    {
        switch (formacion)
        {
            case Formacion.F4_3_3:
                formacionImage.sprite = alineacion[0];
                alineacionNombre.text = formacionImage.sprite.name;
                break;
            case Formacion.F4_4_2:
                formacionImage.sprite = alineacion[1];
                alineacionNombre.text = formacionImage.sprite.name;
                break;
            case Formacion.F4_2_3_1:
                formacionImage.sprite = alineacion[2];
                alineacionNombre.text = formacionImage.sprite.name;
                break;
        }
    }

    public void FormacionSiguiente()
    {
        formacion = (Formacion)(((int)formacion + 1) % System.Enum.GetValues(typeof(Formacion)).Length);
    }

    public void FormacionAnterior()
    {
        formacion = (Formacion)(((int)formacion - 1 + System.Enum.GetValues(typeof(Formacion)).Length) % System.Enum.GetValues(typeof(Formacion)).Length);
    }
}
