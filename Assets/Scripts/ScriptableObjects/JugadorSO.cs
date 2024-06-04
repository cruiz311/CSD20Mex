using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "JugadorSO", menuName = "SO/JugadorSO")]
public class JugadorSO : ScriptableObject
{
    public string nombre;
    public List<Estadisticas> estats;
}

[System.Serializable]
public class Estadisticas
{
    public string name;
    public int valor;
}
