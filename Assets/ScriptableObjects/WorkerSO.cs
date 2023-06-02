using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Worker", menuName = "Worker")]
public class WorkerSO : ScriptableObject
{
    public string pseudonym;
    public string description;

    public Sprite appearance;

    public float feedRate;
    public float playRate;
    public float cleanRate;
    public float healRate;
}
