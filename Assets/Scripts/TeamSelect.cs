using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelect : MonoBehaviour
{
    public LigaSO liga;
    public GameSO game;

    public void EquipoSeleccionado(EquipoSO equipo)
    {
        game.equipoSeleccionado = equipo;
        game.equiposRivales.Clear();
        foreach (var equipos in liga.equipoSO)
        {
            if (equipos != game.equipoSeleccionado)
            {
                game.equiposRivales.Add(equipos);
            }
        }
    }
}

