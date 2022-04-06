using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Puzzle: MonoBehaviour
{
    public float MaxDistance = 1f;
    public Vector3 direction;
    public bool isSolved;

    private void Awake()
    {
        isSolved = false;
    }
    private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, MaxDistance, layerMask))
        {
            if (hit.collider.tag == "Player" && !isSolved)
            {
                Debug.Log(hit.collider.name);
                Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
                DetectionEffects();
                isSolved = true;
            }
        }
    }

    public abstract void DetectionEffects();
}
