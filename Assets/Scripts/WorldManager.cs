using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class WorldManager : MonoBehaviour
{

    public static EntityManager entityManager = World.Active.CreateManager<EntityManager>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
