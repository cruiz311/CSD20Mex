using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pais", menuName = "SO/Pais")]
public class PaisSO : ScriptableObject
{
    public string nombrePais;
    public List<EstadoSO> estadosDelPais;
}
