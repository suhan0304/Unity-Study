using System;
using UnityEngine;

class PositionProcessor {
    public Vector3 process(Transform parent) {
        Vector3 result = Vector3.zero;

        try {
            foreach(Transform child in parent) {
                result += child.position;
            }
        } catch (Exception e) {
            Debug.LogError(e.Message);
        }
    
        return result;
    }
}

class MinusPositionProcessor {
    public Vector3 process(Transform parent) {
        Vector3 result = Vector3.zero;

        try {
            foreach(Transform child in parent) {
                result -= child.position;
            }
        } catch (Exception e) {
            Debug.LogError(e.Message);
        }
    
        return result;
    }
}

public class Processor : MonoBehaviour
{
    private void Start() {
        PositionProcessor positionProcessor = new PositionProcessor();

        Vector3 totalPosition = positionProcessor.process(this.transform);
        
        Debug.Log("Total Position: " + totalPosition);
    }
}
