using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Textos", menuName = "SO/Textos")]
public class TextosSO : ScriptableObject
{
    public string idioma;
    public List<string> scenaCrearPerfil;
    public List<string> scenaPresentacion;
}
