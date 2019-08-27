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
	GameObject birdGameObject;

    private bool wanderingStatus;
    private bool rotatingStatus;

    // Start is called before the first frame update
    void Start()
    {
        
        EntityManager entityManager = World.Active.GetExistingManager<EntityManager>();

        EntityArchetype entityArchetype = entityManager.CreateArchetype
            (
            typeof(Position),
            typeof(RenderMesh),
            typeof(Scale),
            typeof(Rotation),
            typeof(LocalToWorld)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(numberOfBirds, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            int randomBirdMesh = UnityEngine.Random.Range(1, 4);
            if (randomBirdMesh == 1)
			{
				birdGameObject = birdPrefab1;
			}
            if (randomBirdMesh == 2)
			{
				birdGameObject = birdPrefab2;
			}
            if (randomBirdMesh == 3)
			{
				birdGameObject = birdPrefab3;
			}
            Entity entity = entityArray[i];
        
           entityManager.SetSharedComponentData(entity, new RenderMesh { mesh =  birdGameObject.GetComponent<Mesh>()});
            entityManager.SetComponentData(entity, new Position { Value = new float3(0.0f, 0.0f, 0.0f)});
        }
        entityArray.Dispose();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
