using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum TipoJugador
{
    Delantero,
    MedioCentro,
    Defensa,
    Portero
}
[CreateAssetMenu(fileName = "JugadorSO", menuName = "SO/JugadorSO")]
public class JugadorSO : ScriptableObject
{
    public string nombre;
    public TipoJugador tipoJugador;
    public Estadisticas estadisticas;
}

[System.Serializable]
public class Estadisticas
{
    public int disparo;
    public int velocidad;
    public int reflejos;
    public int energía;
}
