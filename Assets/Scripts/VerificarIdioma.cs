using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerificarIdioma : MonoBehaviour
{
    public List<TextMeshProUGUI> textos; // Los elementos de UI que se deben actualizar
    public List<TextosSO> idiomas; // Lista de idiomas disponibles
    public PlayerSO player;

    private void Start()
    {
        if (CreateNewPlayer.instance.nuevoJugador != null)
        {
            player = CreateNewPlayer.instance.nuevoJugador;
            ActualizarTextosScenaCrearPerfil();
        }
    }
    private void Update()
    {
        
        // No necesitas verificar el idioma en cada frame, esto se puede hacer solo cuando cambie el idioma
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
