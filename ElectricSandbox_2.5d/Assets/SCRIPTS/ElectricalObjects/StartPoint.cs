using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : ElectricObject
{
    //public new GameObject[] inputs;
    //public new GameObject[] outputs;
    //public new Tags tag = Tags.STARTPOINT;
    // Start is called before the first frame update
    SimulationManager simulationManager;
    void Start()
    {
        simulationManager = GameObject.Find("SimulationManager").GetComponent<SimulationManager>();
        tags = Tags.STARTPOINT;
    }
    public override void showOutput()
    { }

    public override void sendElectricityTick()
    {
        simulationManager.continueTick = true;
        Debug.Log("START POINT ETICK");
        for (int i = 0; i < outputs.Count; i++)
        {
            ElectricObject e = outputs[i].GetComponent<ElectricObject>();
            if (e != null)
            {
                simulationManager.continueTick = true;
                e.sendElectricityTick();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
