using UnityEngine;

public class ChooseTeam : MonoBehaviour
{
    public GameObject content;
    public PoolControl plataformaPooler;
    public LigaSO liga;

    void Start()
    {
        // Instanciar una plataforma por cada equipo en la lista de liga
        for (int i = 0; i < liga.equipoSO.Count; i++)
        {
            GameObject nuevaPlataforma = plataformaPooler.GetObject();
            nuevaPlataforma.transform.SetParent(content.transform, false);
            Plataforma plataformaScript = nuevaPlataforma.GetComponent<Plataforma>();

            if (plataformaScript != null)
            {
                nuevaPlataforma.name = liga.equipoSO[i].name;
                plataformaScript.ConfigurarPlataforma(liga.equipoSO[i]);
            }
        }
    }
}
