using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelControl : MonoBehaviour
{
    private void Awake()
    {
        switch (score.live)
        {
            case 3:
                break;

            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;

            case 1:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }
}
