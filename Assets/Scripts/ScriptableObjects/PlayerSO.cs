using System;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public string nombre;
    public string apellido;
    public EstadoSO estadoPlayer;
    public string idioma;

    private void OnEnable()
    {
        idioma = "Espanol";
    }

}
