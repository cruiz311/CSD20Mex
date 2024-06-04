using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultadoPartido : MonoBehaviour
{
    [Header("Local")]
    public TextMeshProUGUI nombreLocal;
    public Image spriteLocal;
    public TextMeshProUGUI golesLocal;

    [Header("Visitante")]
    public TextMeshProUGUI nomnbreVisitante;
    public Image spriteVisitante;
    public TextMeshProUGUI golesVisitante;



    public void MostrarLocal(EquipoSO local)
    {
        nombreLocal.text = local.name;
        spriteLocal.sprite = local.LogoEquipo;
    }

    public void MostrarVisita(EquipoSO visitante)
    {
        nomnbreVisitante.text = visitante.name;
        spriteVisitante.sprite = visitante.LogoEquipo;
    }

}
