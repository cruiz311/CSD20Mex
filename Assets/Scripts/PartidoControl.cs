using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System.Xml.Serialization;

public class PartidoControl : MonoBehaviour
{
    public CalendarioSO calendario;
    public GameSO game;
    public TextMeshProUGUI semana;
    public GameObject content;
    public PoolControl tablaPosicionPool;

    void Start()
    {
        ActualizarSemana();
    }
    public void ActualizarSemana()
    {
        game.SemanaActual = calendario.semanas[calendario.semanaActual - 1];
        semana.text = "SEMANA " + calendario.semanaActual;
        // Instanciar una plataforma por cada equipo en la lista de liga
        for (int i = 0; i < tablaPosicionPool.initialPoolSize; i++)
        {
            GameObject PosicionEnTabla = tablaPosicionPool.GetObject();
            PosicionEnTabla.transform.SetParent(content.transform, false);
            ResultadoPartido resultadoPartido = PosicionEnTabla.GetComponent<ResultadoPartido>();
            if (resultadoPartido != null)
            {
                resultadoPartido.MostrarLocal(game.SemanaActual.FechaDePartidos[i].local);
                resultadoPartido.MostrarVisita(game.SemanaActual.FechaDePartidos[i].visita);
            }
        }
    }
}



