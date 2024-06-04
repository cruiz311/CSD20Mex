using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameSO game;
    public Image imagenClub;
    public Semana SemanaActual;
    public CalendarioSO calendarioSO;

    private void Start()
    {
        SemanaActual = ObtenerSemana(calendarioSO.semanaActual);

        if (SemanaActual != null)
        {
            Partido partido = BuscarPartidoDeEquipo(game.equipoSeleccionado, SemanaActual);
            if (partido != null)
            {
                Debug.Log($"El equipo seleccionado se enfrenta contra {(partido.local == game.equipoSeleccionado ? partido.visita.name : partido.local.name)}");
            }
            else
            {
                Debug.Log("El equipo seleccionado no tiene partido esta semana.");
            }
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
}