using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform[] points;
    public NavMeshAgent agent;
    public int contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        agent.autoBraking = false;
        GotoNextPoint();
    }
    /*
     Este metodo fue obtenido de la documentacion de Patrol de Unity, en el enlace https://docs.unity3d.com/Manual/nav-AgentPatrol.html
    */
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[contador].position;
        
        contador = (contador + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
