using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCheck : MonoBehaviour
{
    BuildingManager buildingManager;

    // Start is called before the first frame update
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ElectricalObject"))
        {
            buildingManager.canPlace = false;
        }

        if (other.gameObject.CompareTag("ElectricalObjectVO"))
        {
            buildingManager.canPlace = false;
        }

        if (other.gameObject.CompareTag("ElectricalObjectSP"))
        {
            buildingManager.canPlace = false;
        }
        if (other.gameObject.CompareTag("ElectricalObjectEP"))
        {
            buildingManager.canPlace = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ElectricalObject"))
        {
            buildingManager.canPlace = true;
        }
        if (other.gameObject.CompareTag("ElectricalObjectVO"))
        {
            buildingManager.canPlace = true;
        }
        if (other.gameObject.CompareTag("ElectricalObjectSP"))
        {
            buildingManager.canPlace = true;
        }
        if (other.gameObject.CompareTag("ElectricalObjectEP"))
        {
            buildingManager.canPlace = true;
        }
    }
}
