using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameSO", menuName = "SO/GameSO")]
public class GameSO : ScriptableObject
{
    public EquipoSO equipoSeleccionado;
    public List<EquipoSO> equiposRivales;

    public void OnEnable()
    {
        equipoSeleccionado = null;
        equiposRivales = new List<EquipoSO>();
    }
}

