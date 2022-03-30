using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandlerBehaviour : MonoBehaviour
{
    private GunBehaviour[] gunBehaviours;
    private int activeGun = 0;

   

    private void Awake()
    {
        gunBehaviours = GetComponentsInChildren<GunBehaviour>();

    }

    public void shoot(Vector2 direction)
    {
        gunBehaviours[activeGun].wantsToShoot(direction);
    }

    private void disableGuns(int exception)
    {
        for (int x = 0; x < gunBehaviours.Length; x++)
        {
            if (x != exception)
            {
                gunBehaviours[x].gameObject.SetActive(false);
            }
        }
        activeGun = exception;
    }

    private void Start()
    {
        disableGuns(0);
    }

   

}
