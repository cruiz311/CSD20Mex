using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenarTabla : MonoBehaviour
{
    public GameObject content;
    public PoolControl tablaPosicionPool;
    public int cantidad;
    public LigaSO liga;

    void Start()
    {
        // Instanciar una plataforma por cada equipo en la lista de liga
        for (int i = 0; i < cantidad; i++)
        {
            GameObject PosicionEnTabla = tablaPosicionPool.GetObject();
            PosicionEnTabla.transform.SetParent(content.transform, false);
            TablaPosicion tablaPosicion = PosicionEnTabla.GetComponent<TablaPosicion>();
            if(tablaPosicion != null)
            {
                tablaPosicion.posicion.text = (i+1).ToString();
                tablaPosicion.configurarTablaPosicion(liga.tablaPosiciones[i]);
            }
        }
    }
}
