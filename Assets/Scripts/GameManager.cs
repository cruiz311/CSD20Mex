using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameSO game;
    public Image imagenClub;
    public Semana SemanaActual;
    public CalendarioSO calendarioSO;
    public EquipoSO equipoRival;
    public Image equipoRivalImagen;

    private void Start()
    {
        imagenClub.sprite = game.equipoSeleccionado.LogoEquipo;
        SemanaActual = ObtenerSemana(calendarioSO.semanaActual);
        Partido partido = BuscarPartidoDeEquipo(game.equipoSeleccionado, SemanaActual);

        if (partido.local == game.equipoSeleccionado)
        {
            equipoRival = partido.visita;
            equipoRivalImagen.sprite = equipoRival.LogoEquipo;
        }
        else
        {
            equipoRival = partido.local;
            equipoRivalImagen.sprite = equipoRival.LogoEquipo;
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