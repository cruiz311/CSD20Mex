using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LigaSO", menuName = "SO/LigaSO")]
public class LigaSO : ScriptableObject
{
    public List<EquipoSO> equipoSO;

    [Header("Posiciones")]
    public List<EquipoSO> tablaPosiciones;


    private void OnEnable()
    {
        OrdenarPorDiferenciaDeGoles();
    }
    public void OrdenarPorDiferenciaDeGoles()
    {
        tablaPosiciones = equipoSO;
        tablaPosiciones.Sort((equipo1, equipo2) => equipo2.puntos.CompareTo(equipo1.puntos));
    }
}
