using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBakingBread : MonoBehaviour
{
    public void MoveMe(GameObject dest)
    {
        this.transform.SetParent(dest.transform);
        this.transform.localPosition = Vector3.zero;
    }
}
