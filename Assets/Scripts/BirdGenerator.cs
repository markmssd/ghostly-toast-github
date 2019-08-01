using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class BirdGenerator : MonoBehaviour
{
    public int numberOfBirds;
    public GameObject birdPrefab1;
    public GameObject birdPrefab2;
    public GameObject birdPrefab3;

    private bool wanderingStatus;
    private bool rotatingStatus;

    // Start is called before the first frame update
    void Start()
    {
        EntityArchetype entityArchetype = WorldManager.entityManager.CreateArchetype
            (
            typeof(Transform),
            typeof(RenderMesh),
            typeof(Scale),
            typeof(Rotation),
            typeof(LocalToWorld)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(numberOfBirds, Allocator.Temp);

        WorldManager.entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            int randomBirdMesh = UnityEngine.Random.Range(1, 4);
            string chosenBirdPrefab = string.Format("birdPrefab{0}", randomBirdMesh);
            GameObject birdGameObject = GameObject.Find(chosenBirdPrefab);

            Entity entity = entityArray[i];

            WorldManager.entityManager.SetSharedComponentData(entity, new RenderMesh { mesh = birdGameObject.GetComponent<Mesh>()});
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
