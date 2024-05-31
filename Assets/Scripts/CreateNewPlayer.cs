using System.Collections.Generic;
using System.IO;
using TreeEditor;
using UnityEditor;
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

    public void GuardarJugador()
    {
        string fullPath = Path.Combine(BASE_PATH, nuevoJugador.nombre + ".asset");

        AssetDatabase.CreateAsset(nuevoJugador, fullPath);
        AssetDatabase.SaveAssets();
        GuardarPerfiles();
    }
    public void GuardarPerfiles()
    {
        string listPath = Path.Combine(BASE_PATH, "Perfiles.json");

        if (File.Exists(listPath))
        {
            string jsonData = File.ReadAllText(listPath);
            Perfiles = JsonUtility.FromJson<CreateNewPlayer>(jsonData).Perfiles;
        }

        Perfiles.Add(nuevoJugador);
        string json = JsonUtility.ToJson(Perfiles, true);

        File.WriteAllText(listPath, json);
    }

}
