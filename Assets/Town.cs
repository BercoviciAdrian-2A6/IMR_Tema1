using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    public int townLvl;
    public GameObject[] towns;
    public float townEtmr = 0;
    public GameObject drakePref;
    public GameObject drakeClone;

    public void levelUp()
    {
        townLvl++;

        if (townLvl > 5)
        {
            townLvl = 5;

            if (drakeClone == null)
            {
                drakeClone = Instantiate(drakePref, drakePref.transform.parent);

                drakeClone.GetComponent<Drake>().targetPos = gameObject;

                drakeClone.SetActive(true);
            }
        }

        for (int i = 0; i < towns.Length; i++)
        {
            if (i == townLvl)
                towns[i].SetActive(true);
            else
                towns[i].SetActive(false);
        }
    }

    void Update()
    {
        townEtmr += Time.deltaTime;
    }
}
