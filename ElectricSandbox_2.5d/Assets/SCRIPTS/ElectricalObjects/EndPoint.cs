using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : ElectricObject
{
    //public new GameObject[] inputs;
    //public new GameObject[] outputs;
    public SimulationManager simulationManager;
    //public Tags tags = Tags.ENDPOINT;
    // Start is called before the first frame update
    void Start()
    {
        simulationManager = GameObject.Find("SimulationManager").GetComponent<SimulationManager>();
        simulationManager.addEndPoint();
        
        tags = Tags.ENDPOINT;
    }
    public override void showOutput()
    { }

    public override void sendElectricityTick()
    {
        Debug.Log("Endpoint ETICK");
        simulationManager.continueTick = false;
        simulationManager.endPointReached();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
