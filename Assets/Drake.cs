using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drake : MonoBehaviour
{
    public GameObject targetPos;
    public float flightSpeed;
    public bool animPlayed = false;
    public Animator drakeAnim;
    bool leaving = false;

    public void fireTown()
    {
        Destroy(targetPos);

        drakeAnim.SetTrigger("Leave");

        leaving = true;
    }

    void Update()
    {
        if (leaving)
        {
            Vector3 tp = new Vector3(10000, 0, 10000);

            transform.forward = Vector3.RotateTowards(transform.forward, tp - transform.position, 60 * Mathf.Deg2Rad * Time.deltaTime, 0);
            transform.position += transform.forward * flightSpeed * Time.deltaTime;

            return;
        }

        if (Vector3.Distance(targetPos.transform.position, transform.position) > 0.5)
        {
            transform.forward = Vector3.RotateTowards(transform.forward, targetPos.transform.position - transform.position, 60 * Mathf.Deg2Rad * Time.deltaTime, 0);
            transform.position += transform.forward * flightSpeed * Time.deltaTime;
        }
        else
        {
            if (!animPlayed)
            {
                animPlayed = true;
                drakeAnim.SetTrigger("Fire");
            }
        }
    }
}
