using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipoSO", menuName = "SO/EquipoSO")]
public class EquipoSO : ScriptableObject
{
    [Header("Datos Equipo")]
    public List<JugadorSO> Plantel;
    [Header("Datos Estadisticos")]
    public Sprite LogoEquipo;
    public string InformacionEquipo;
    public string NombreEstadio;
    public Sprite SpriteEstadio;
    public int Dinero;
    [Header("Datos Liga")]
    public string Abreviacion;
    public int puntos;
    public int PartidosJugados;
    public int PartidosGanados;
    public int PartidosPerdidos;
    public int PartidosEmpatados;
    public int GolesAnotados;
    public int GolesRecibidos;
    public int DiferenciaGoles;

    private void OnEnable()
    {
        PartidosJugados = PartidosGanados + PartidosEmpatados + PartidosPerdidos;
        puntos = PartidosGanados * 3 + PartidosEmpatados * 1;
        DiferenciaGoles = GolesAnotados - GolesRecibidos;
    }
}
