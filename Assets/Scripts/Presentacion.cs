using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Presentacion : MonoBehaviour
{
    public List<string> textosPresentacion;
    public TextMeshProUGUI texto;
    private int currentIndex = 0;

    // Método para inicializar el primer texto
    void Start()
    {
        if (textosPresentacion.Count > 0)
        {
            StartCoroutine(TypeText(textosPresentacion[currentIndex]));
        }
    }
    public void nextTextos()
    {
        currentIndex++;
        if (currentIndex >= textosPresentacion.Count)
        {
            SceneManager.LoadScene("ChoseTeam");
        }
        if(currentIndex < textosPresentacion.Count)
        {
            StopAllCoroutines();
            StartCoroutine(TypeText(textosPresentacion[currentIndex]));
        }
    }

    private IEnumerator TypeText(string text)
    {
        texto.text = ""; 
        foreach (char letter in text.ToCharArray())
        {
            texto.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    public void EndTextos()
    {
        SceneManager.LoadScene("ChoseTeam");
    }
}
