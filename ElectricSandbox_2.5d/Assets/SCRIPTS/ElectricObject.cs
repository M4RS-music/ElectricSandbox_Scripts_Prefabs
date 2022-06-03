using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElectricObject : MonoBehaviour
{
    public List<GameObject> inputs;
    public List<GameObject> outputs;

    public List<GameObject> wires;

    public GameObject opos;
    public GameObject ipos;

    public Tags tags;

    public abstract void sendElectricityTick();

    public abstract void showOutput();
}
