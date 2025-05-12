using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class ARManager : MonoBehaviour
{
    public TMP_Text texto;
    public Button botonDeBorrar;
    public TMP_Dropdown botonDropDown;

    public ARPlaneManager ManagerDelPlano;

    public GameObject[] prefabOpciones;
    private int prefabSeleccionado = 0;
    private List<GameObject> instancias = new List<GameObject>();

    void Start()
    {
        
        botonDeBorrar.onClick.AddListener(BorrarInstancias);
        botonDropDown.onValueChanged.AddListener(CambiarPrefabSeleccionado);

        
        if (botonDropDown.options.Count == 0)
        {
            botonDropDown.ClearOptions();
            List<string> nombres = new List<string>();
            foreach (GameObject prefab in prefabOpciones)
            {
                nombres.Add(prefab.name);
            }
            botonDropDown.AddOptions(nombres);
        }
    }

    void Update()
    {
        if (ManagerDelPlano != null)
        {
            texto.text = "Planos detectados: " + ManagerDelPlano.trackables.count;
        }
    }

    public void InstanciarPrefab(Vector3 posicion)
    {
        GameObject nuevo = Instantiate(prefabOpciones[prefabSeleccionado], posicion, Quaternion.identity);
        instancias.Add(nuevo);
    }

    void BorrarInstancias()
    {
        foreach (GameObject obj in instancias)
        {
            Destroy(obj);
        }
        instancias.Clear();
    }

    void CambiarPrefabSeleccionado(int index)
    {
        prefabSeleccionado = index;
    }
}
