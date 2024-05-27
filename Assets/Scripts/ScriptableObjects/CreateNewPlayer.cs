using System.Collections.Generic;
using System.IO;
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
            CrearNuevoJugador();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void CrearNuevoJugador()
    {
        nuevoJugador = ScriptableObject.CreateInstance<PlayerSO>();
        Perfiles.Add(nuevoJugador);
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

        List<string> perfilesJson = new List<string>();

        foreach (PlayerSO perfil in Perfiles)
        {
            string json = JsonUtility.ToJson(perfil);
            perfilesJson.Add(json);
        }
        string jsonCompleto = string.Join("\n", perfilesJson.ToArray());

        File.WriteAllText(listPath, jsonCompleto);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
