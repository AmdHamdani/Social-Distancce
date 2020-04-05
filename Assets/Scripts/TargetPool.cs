using System.Collections.Generic;
using UnityEngine;

public class TargetPool : MonoBehaviour
{

    public Transform CurrentTarget;
    public List<GameObject> targets = new List<GameObject>();

    // Start is called before the first frame update
    private void Awake()
    {
        targets.AddRange(GameObject.FindGameObjectsWithTag("Target"));
        CurrentTarget = targets[Random.Range(0, targets.Count)].transform;
    }

}
