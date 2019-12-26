﻿using UnityEngine;
using UnityEngine.AI;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField]
    GameObject towerPrefab;

    private NavMeshSurface[] navMeshes;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Terrain")
            {
                Transform objectHit = hit.transform;

                transform.position = new Vector3(objectHit.position.x, transform.position.y, objectHit.position.z);

            }
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
            if (colliders.Length <= 0)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);

                navMeshes = FindObjectsOfType<NavMeshSurface>();
                
                foreach(NavMeshSurface navMesh in navMeshes)
                {
                    navMesh.BuildNavMesh();
                }

                Destroy(this.gameObject);
            }
        }
    }
}
