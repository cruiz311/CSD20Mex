using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class LoginRegister : MonoBehaviour
{
    [Header("Titulo")]
    public TextMeshProUGUI texto;
    [Header("InicioSesion")]
    public GameObject IniciarSesion;
    [Header("RegistrarUsuario")]
    public GameObject RegistarUsuario;
    public TextMeshProUGUI usuarioRegistrado;
    public TextMeshProUGUI correoElectronico;
    public void VerificarRegistro()
    {
        Debug.Log(correoElectronico.text);
        if (correoElectronico.text.EndsWith("gmail.com​"))
        {
            StartCoroutine(ShowMessage2("Usuario Registrado Exitosamente"));
        }
        else
        {
            StartCoroutine(ShowMessage("Ese correo no pertenece a Gmail"));
        }
    }
    public void RegistarUsuarioUI()
    {
        IniciarSesion.SetActive(false);
        texto.text = "Registrar Usuario";
        RegistarUsuario.SetActive(true);
    }
    public void IniciarSesionUI()
    {
        RegistarUsuario.SetActive(false);
        texto.text = "Iniciar Sesion";
        IniciarSesion.SetActive(true);
    }
    IEnumerator ShowMessage(string message)
    {
        usuarioRegistrado.text = "";
        foreach (char letter in message)
        {
            usuarioRegistrado.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
    }
    IEnumerator ShowMessage2(string message)
    {
        usuarioRegistrado.text = "";
        foreach (char letter in message)
        {
            usuarioRegistrado.text += letter;
            yield return new WaitForSeconds(0.05f); 
        }
        yield return new WaitForSeconds(1f); 
        IniciarSesionUI();
    }
}
