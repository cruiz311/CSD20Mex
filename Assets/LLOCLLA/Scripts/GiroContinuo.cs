using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroContinuo : MonoBehaviour
{
    public int valor = 250;
    void Update()
    {
        transform.Rotate(new Vector3(valor, valor, valor) * Time.deltaTime);
    }
}
