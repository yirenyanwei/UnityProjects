using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavigation : MonoBehaviour
{
    [Header("导航目标")]
    public Transform Target;
    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        //设置导航目的地
        nav.SetDestination(Target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
