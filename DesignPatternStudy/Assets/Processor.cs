using System;
using UnityEngine;

abstract class PositionProcessor {
    public Vector3 process(Transform parent) {
        Vector3 result = Vector3.zero;

        try {
            foreach (Transform child in parent) {
                result = calculate(result, child);
            }
        } catch (Exception e) {
            Debug.LogError(e.Message);
        }
    
        return result;
    }

    protected abstract Vector3 calculate(Vector3 result, Transform parent);
}

class PlusPositionProcessor : PositionProcessor{
    protected override Vector3 calculate(Vector3 result, Transform child) {
        return result += child.position;
    }
}

class MinusPositionProcessor : PositionProcessor{
    protected override Vector3 calculate(Vector3 result, Transform child) {
        return result -= child.position;
    }
}

public class Processor : MonoBehaviour
{
    private void Start() {
        PlusPositionProcessor plusPositionProcessor = new PlusPositionProcessor();
        Vector3 totalPosition1 = plusPositionProcessor.process(this.transform);
        Debug.Log("Total Position: " + totalPosition1);

        
        MinusPositionProcessor minusPositionProcessor = new MinusPositionProcessor();
        Vector3 totalPosition2 = minusPositionProcessor.process(this.transform);
        Debug.Log("Total Position: " + totalPosition2);
    }
}
