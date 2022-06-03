using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public bool simulate = false;
    private int endPoints = 0;
    private int endPointsReached = 0;
    public GameObject[] startPoints;
    public bool continueTick = false;

    public GameObject simulating;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addEndPoint()
    {
        endPoints++;
    }
    public void removeEndPoint()
    {
        endPoints--;
    }

    public void endPointReached()
    {
        endPointsReached++;
    }

    public void StartSimulation()
    {
        simulate = true;
        simulating.SetActive(true);
        startPoints = GameObject.FindGameObjectsWithTag("ElectricalObjectSP");
    }

    public void EndSimulation()
    {
        simulate = false;
        simulating.SetActive(false);
    }

    private void updateVisuals()
    {
        GameObject[] visualOutputObjects = GameObject.FindGameObjectsWithTag("ElectricalObjectVO");
        for (int i = 0; i < visualOutputObjects.Length; i++)
        {
            visualOutputObjects[i].GetComponent<ElectricObject>().showOutput();
        }
    }


    // Update is called once per frame
    void Update()
    {
       


        if (simulate)
        {
            continueTick = true;
            //Debug.Log(continueTick);
            
            ///Set off electrical tick chain
            for (int i = 0; i < startPoints.Length; i++)
            {
                //Debug.Log(startPoints[i]);
                startPoints[i].GetComponent<ElectricObject>().sendElectricityTick();
                GameObject x = startPoints[i];
                ElectricObject y = x.GetComponent<ElectricObject>();
                //Debug.Log(y);
               // y.sendElectricityTick();
                y.sendElectricityTick();
            }
            int l = 0;
            while (continueTick)
            {
                if (l < 99999999)
                {
                    l++;
                }
                else
                {
                    break;
                }
                //Debug.Log("cont");
            }
            ///wait for simulation
            
            updateVisuals();
           
        }
    }
}
