using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    bool downed = false;
    public BuildingManager buildingManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buildingManager.lmbDown && !downed)
        {
            downed = true;
            Ray ray = Camera.main.ScreenPointToRay(buildingManager.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage    
                if (hit.collider.gameObject.layer == 3)
                {

                    Switch x = hit.collider.gameObject.GetComponent<Switch>();
                    if (x != null)
                    {
                        
                        x.toggleState();
                    }
                    else
                    {
                       MomentarySwitch z = hit.collider.gameObject.GetComponent<MomentarySwitch>();
                       z.toggleState();
                       Debug.Log("momentary switch");
                    }
                    
                   
                }
            }
        }
        if (!buildingManager.lmbDown && downed)
        {
            downed = false;
            Ray ray = Camera.main.ScreenPointToRay(buildingManager.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage    
                if (hit.collider.gameObject.layer == 3)
                {

                    MomentarySwitch z = hit.collider.gameObject.GetComponent<MomentarySwitch>();
                    if(z != null)
                    {
                        z.toggleState();
                    }
                }
            }
        }
    }
}
