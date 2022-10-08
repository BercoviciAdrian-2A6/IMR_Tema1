using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCollisionController : MonoBehaviour
{
    public Town town;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Town")
        {
            Town otherTown = other.gameObject.GetComponent<Town>();

            if (town.townEtmr >= otherTown.townEtmr)
            {
                town.levelUp();
                Destroy(other.gameObject);
            }
        }
    }

}
