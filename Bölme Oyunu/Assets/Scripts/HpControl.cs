using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpControl : MonoBehaviour
{
    [SerializeField] private GameObject HPbar1,HPbar2,HPbar3;

    public void CheckHealth(int remainBar)
    {
        switch (remainBar)
        {
            case 3:
                HPbar1.SetActive(true);
                HPbar2.SetActive(true);
                HPbar3.SetActive(true);
                break;

            case 2:
                HPbar1.SetActive(true);
                HPbar2.SetActive(true);
                HPbar3.SetActive(false);
                break;

            case 1:
                HPbar1.SetActive(true);
                HPbar2.SetActive(false);
                HPbar3.SetActive(false);
                break;

            case 0:
                HPbar1.SetActive(false);
                HPbar2.SetActive(false);
                HPbar3.SetActive(false);
                break;
        }
    }
}
