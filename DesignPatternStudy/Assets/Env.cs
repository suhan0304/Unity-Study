using System.Collections.Generic;
using UnityEngine;

public class Env : MonoBehaviour
{
    private void Start()
    {
        EnvObjAbstractFactoryMethod factory = null;

        factory = ForestFactoryMethod.GetInstance();
        List<EnvObj> list = factory.createOperation();

        foreach (EnvObj obj in list)
        {
            obj.Create();
        }
    }
}
