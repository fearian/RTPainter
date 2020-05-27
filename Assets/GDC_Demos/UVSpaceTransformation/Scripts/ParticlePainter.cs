using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePainter : RaycastPainter
{
    [SerializeField] ParticleSystem _particles;
    private List<ParticleCollisionEvent> collisionEvents;
    
    void Start() {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    //TODO:
    // -> find a way to use particle size. Can't get from collision, but maybe just randomize the painter size?
    // -> find a way to use multiple painters.
    // -> find a way to use multiple render textures.
    // -> instead of using a sphere mask, use a decal?
    // -> create normals from this mask
    // -> improve the material.  


    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponent<UVSpaceRenderer>() != null)
        {
            UVSpaceRenderer target = other.gameObject.GetComponent<UVSpaceRenderer>();
        
        ParticlePhysicsExtensions.GetCollisionEvents(_particles, other, collisionEvents);
        //Painter[] collisionPainters = new Painter[collisionEvents.Count];

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            Vector3 spawnPos = collisionEvents[i].intersection;
            Painter newPainter = Instantiate(_painter, spawnPos, Quaternion.identity);
            newPainter.mode = Painter.Mode.Additive;
            newPainter.gameObject.SetActive(true);
             target.takePainters(newPainter);
            //collisionPainters[i] = newPainter;
        }

/*         foreach (Painter newPainter in collisionPainters)
        {
           Destroy(newPainter.gameObject);
        } */
        }
    }


    void Update()
    {
        /* if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Vector3 position = (Vector3)Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                _painter.transform.position = hit.point;
            }

            bool didHit = hit.transform != null;

            _painter.gameObject.SetActive(didHit);
            if (Input.GetMouseButton(0))
            {
                _painter.mode = Painter.Mode.Additive;
            }
            else if (Input.GetMouseButton(1))
            {
                _painter.mode = Painter.Mode.Subtractive;
            }

            if (didHit)
            {
                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
            }
        }
        else
        {
            _painter.gameObject.SetActive(false);
        } */
    }
}
