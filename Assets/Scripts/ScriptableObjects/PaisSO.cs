using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PaisSO", menuName = "SO/PaisSO")]
public class PaisSO : ScriptableObject
{
    public string nombrePais;
    public List<LigaSO> LigasDelPais;
}
