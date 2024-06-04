using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CrearCalendario : MonoBehaviour
{
    public LigaSO liga;
    public CalendarioSO calendarioSO;
    private void Start()
    {
        
        calendarioSO.semanas = CrearPartidosPorSemana(liga.equipoSO);
        
    }

    public List<Semana> CrearPartidosPorSemana(List<EquipoSO> equipos)
    {
        int cantidadSemanas = equipos.Count - 1;
        int partidosPorSemana = equipos.Count / 2;

        List<Semana> calendario = new List<Semana>();

        for (int i = 0; i < cantidadSemanas; i++)
        {
            Semana semanaActual = new Semana();
            semanaActual.numeroSemana = "Semana " + (i + 1);
            semanaActual.FechaDePartidos = new List<Partido>();

            for (int j = 0; j < partidosPorSemana; j++)
            {
                int local = (i + j) % (equipos.Count - 1);
                int visita = (equipos.Count - 1 - j + i) % (equipos.Count - 1);

                if (j == 0)
                {
                    visita = equipos.Count - 1;
                }

                // Verificar si los equipos ya se han enfrentado previamente
                bool enfrentamientoRepetido = semanaActual.FechaDePartidos.Any(p =>
                    (p.local == equipos[local] && p.visita == equipos[visita]) ||
                    (p.local == equipos[visita] && p.visita == equipos[local]));

                if (!enfrentamientoRepetido)
                {
                    Partido partidoActual = new Partido();
                    partidoActual.local = equipos[local];
                    partidoActual.visita = equipos[visita];
                    semanaActual.FechaDePartidos.Add(partidoActual);
                }
                else
                {
                    j--;
                }
            }

            calendario.Add(semanaActual);
        }
        return calendario;
    }
}
