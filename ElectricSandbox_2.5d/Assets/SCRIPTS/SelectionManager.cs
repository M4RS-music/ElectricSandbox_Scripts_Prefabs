using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;


public class SelectionManager : MonoBehaviour
{
    BuildingManager buildingManager;
    SimulationManager simulationManager;
    public GameObject selectedObject;
    Vector3 mousePosition;

    public TextMeshProUGUI selectedObjectName;
    // Start is called before the first frame update
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        if (buildingManager.lmbDown)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("ElectricalObject"))
                {
                    select(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.CompareTag("ElectricalObjectSP"))
                {
                    select(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.CompareTag("ElectricalObjectVO"))
                {
                    select(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.CompareTag("ElectricalObjectEP"))
                {
                    select(hit.collider.gameObject);
                }
            }
        }
        if (buildingManager.rmbDown && selectedObject != null)
        {
            deselect();
        }

    }

    public void move() {
        buildingManager.currentObject = selectedObject;
        ElectricObject e = buildingManager.currentObject.GetComponent<ElectricObject>();
        for (int i = 0; i < e.wires.Count; i++)
        {
            //e.wires[i].SetActive(false);
            Destroy(e.wires[i]);

        }

    }
    public void delete()
    {
        GameObject d = selectedObject;
        if(d.CompareTag("ElectricalObjectEP"))
        {
            simulationManager.removeEndPoint();
        }

        ElectricObject e = selectedObject.GetComponent<ElectricObject>();
        for (int i = 0; i < e.wires.Count; i++)
        {
            //e.wires[i].SetActive(false);
            Destroy(e.wires[i]);

        }
        deselect();
        Destroy(d);
    }


    private void select(GameObject obj)
    {
        if (obj == selectedObject) return;
        if (selectedObject != null) deselect();
        Outline outline = obj.GetComponent<Outline>();

        selectedObjectName.text = obj.name.Substring(0, obj.name.IndexOf('(')); ;
        if (outline == null)
        {
            obj.AddComponent<Outline>();
        }
        else
        {
            outline.enabled = true;
        }
        selectedObject = obj;
    } 
    public void deselect()
    {
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }
}
