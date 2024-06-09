using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiEquipoAlineacion : MonoBehaviour
{

    [Header("AlineacionUI")]
    public TextMeshProUGUI nombreAlineacion;
    public Image alineacion;
    [Header("Jugadores")]
    public List<JugadorSO> MisJugadores;

    private void Awake()
    {
        MisJugadores = GameManager.Instance.game.equipoSeleccionado.Plantel;
    }
    private void Update()
    {
        AlineacionSeleccionada();
    }
    public void AlineacionSeleccionada()
    {
        switch (GameManager.Instance.formacion)
        {
            case Formacion.F4_3_3:
                alineacion.sprite = GameManager.Instance.alineacion[0];
                nombreAlineacion.text = alineacion.sprite.name;
                break;
            case Formacion.F4_4_2:
                alineacion.sprite = GameManager.Instance.alineacion[1];
                nombreAlineacion.text = alineacion.sprite.name;
                break;
            case Formacion.F4_2_3_1:
                alineacion.sprite = GameManager.Instance.alineacion[2];
                nombreAlineacion.text = alineacion.sprite.name;
                break;
        }
    }
    public void Der()
    {
        GameManager.Instance.FormacionSiguiente();
    }
    public void Izq()
    {
        GameManager.Instance.FormacionAnterior();
    }
}
