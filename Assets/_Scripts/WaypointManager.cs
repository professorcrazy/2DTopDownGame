using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public Transform[] waypoints;
    private void Awake() {
        Transform[] temp = GetComponentsInChildren<Transform>();
        waypoints = new Transform[temp.Length - 1];
        for (int i = 0; i < temp.Length - 1; i++) {
            waypoints[i] = temp[i + 1].transform;
        }
    }
}
