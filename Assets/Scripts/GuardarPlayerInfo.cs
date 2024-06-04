using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GuardarPlayerInfo : MonoBehaviour
{
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI apellido;
    public PlayerSO player;


    private void Start()
    {
        if (CreateNewPlayer.instance.nuevoJugador != null)
        {
            player = CreateNewPlayer.instance.nuevoJugador;
        }
    }
    public void GuardarInfo()
    {
        // Verificar y asignar nombre si no está vacío
        if (!string.IsNullOrWhiteSpace(nombre.text))
        {
            player.nombre = nombre.text;
        }

        // Verificar y asignar apellido si no está vacío
        if (!string.IsNullOrWhiteSpace(apellido.text))
        {
            player.apellido = apellido.text;
        }

        // Verificar que player.nombre, apellido y player.estado.nombre no estén vacíos
        if (!string.IsNullOrWhiteSpace(player.nombre) && !string.IsNullOrWhiteSpace(player.apellido) && player.estadoPlayer != null)
        {
            //CreateNewPlayer.instance.GuardarJugador();
            SceneManager.LoadScene("Presentacion");
        }
    }
}
