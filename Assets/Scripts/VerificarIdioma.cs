using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class VerificarIdioma : MonoBehaviour
{
    public List<TextMeshProUGUI> textos; // Los elementos de UI que se deben actualizar
    public List<TextosSO> idiomas; // Lista de idiomas disponibles
    public PlayerSO player;
    public string idioma;
    private void Start()
    {
        if (CreateNewPlayer.instance.nuevoJugador != null)
        {
            player = CreateNewPlayer.instance.nuevoJugador;
            ActualizarTextosScenaCrearPerfil();
        }
    }

    public void OnClickChangeIdiomaSeleccion(string idioma)
    {
        player.idioma = idioma;
        ActualizarTextosScenaCrearPerfil(); // Actualiza los textos cuando se cambie el idioma
    }

    private void ActualizarTextosScenaCrearPerfil()
    {
        // Encuentra el conjunto de textos para el idioma seleccionado
        TextosSO textosDelIdioma = idiomas.Find(id => id.idioma == player.idioma);

        if (textosDelIdioma != null)
        {
            // Asegúrate de que la cantidad de textos coincida
            for (int i = 0; i < textos.Count; i++)
            {
                if (i < textosDelIdioma.scenaCrearPerfil.Count)
                {
                    textos[i].text = textosDelIdioma.scenaCrearPerfil[i];
                }
            }
        }
    }
}
