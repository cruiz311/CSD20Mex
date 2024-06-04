using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CalendarioSO", menuName = "SO/CalendarioSO", order = 1)]
public class CalendarioSO : ScriptableObject
{
    public List<Semana> semanas = new List<Semana>();
    public int semanaActual;
}

[Serializable]
public class Semana
{
    public string numeroSemana;
    public List<Partido> FechaDePartidos;
}
[Serializable]
public class Partido
{
    public string id;
    public EquipoSO local;
    public EquipoSO visita;

    public int golLocal;
    public int golVisita;
}
