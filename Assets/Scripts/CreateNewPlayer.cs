using System.Collections.Generic;
using UnityEngine;

public class CreateNewPlayer : MonoBehaviour
{
    public List<PlayerSO> Perfiles;
    public static CreateNewPlayer instance;
    public PlayerSO nuevoJugador;

    private const string BASE_PATH = @"Assets\Scripts\ScriptableObjects\PlayerData";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            CrearNuevoJugador();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void CrearNuevoJugador()
    {
        nuevoJugador = ScriptableObject.CreateInstance<PlayerSO>();
        nuevoJugador.name = "NuevoUsuario";
    }

    //public void GuardarJugador()
    //{
    //    string fullPath = Path.Combine(BASE_PATH, nuevoJugador.nombre + ".asset");

    //    AssetDatabase.CreateAsset(nuevoJugador, fullPath);
    //    AssetDatabase.SaveAssets();
    //}
}
