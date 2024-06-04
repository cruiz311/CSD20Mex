using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TablaPosicion : MonoBehaviour
{
    public TextMeshProUGUI posicion;
    public Image logoEquipo;
    public TextMeshProUGUI nombreEquipo;
    public TextMeshProUGUI diferenciaGoles;
    public TextMeshProUGUI puntos;


    public void configurarTablaPosicion(EquipoSO equipo)
    {
        logoEquipo.sprite = equipo.LogoEquipo;
        nombreEquipo.text  = equipo.Abreviacion;
        diferenciaGoles.text= equipo.DiferenciaGoles.ToString();
        puntos.text = equipo.puntos.ToString();
    }
}
