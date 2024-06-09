using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CalendarioSO", menuName = "SO/CalendarioSO", order = 1)]
public class CalendarioSO : ScriptableObject
{
    public List<Semana> semanas = new List<Semana>();
    public int semanaActual;

    private void OnEnable()
    {
        semanas.Clear();
        semanaActual = 1;
    }

    public void SiguienteSemana()
    {
        semanaActual++;
    }
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
    public EquipoSO local;
    public int golLocal;
    public EquipoSO visita;
    public int golVisita;
}
