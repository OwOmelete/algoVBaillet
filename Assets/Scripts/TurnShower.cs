using System;
using UnityEngine;

public class TurnShower : MonoBehaviour
{
    [SerializeField] private Material yellow;
    [SerializeField] private Material red;
    [SerializeField] private Game gameManager;
    private Material material;

    void Start()
    { 
        //material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (gameManager.player == 1)
        {
            GetComponent<MeshRenderer>().material = yellow;
        }
        else
        {
            GetComponent<MeshRenderer>().material = red;
        }
    }
}
