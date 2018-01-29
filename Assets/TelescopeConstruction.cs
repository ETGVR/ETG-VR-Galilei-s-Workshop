using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TelescopeConstruction : MonoBehaviour
{
    public enum LENSES
    {
        Concave,
        Convex,
        None
    }
    public LENSES[] correctLensPositions = { LENSES.Concave, LENSES.Convex, LENSES.Concave};
    public LENSES[] currentLensPositions = { LENSES.None, LENSES.None, LENSES.None };

    public void SetLens(int index, LENSES type)
    {
        currentLensPositions[index] = type;
    }

    public bool IsCorrectlyConstructed()
    {
        return currentLensPositions.SequenceEqual<LENSES>(correctLensPositions);
    }
}
