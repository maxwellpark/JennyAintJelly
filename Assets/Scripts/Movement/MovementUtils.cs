using UnityEngine;

public enum Axis
{
    X, Y
}

public static class MovementUtils
{
    public static bool IsAxisDominant(Vector3 input, Axis axis)
    {
        if (axis == Axis.X)
        {
            return Mathf.Abs(input.x) > Mathf.Abs(input.y);
        }
        else if (axis == Axis.Y)
        {
            return Mathf.Abs(input.y) > Mathf.Abs(input.x);
        }
        return false;
    }

    public static bool IsCoordAboveThreshold(Vector3 input, Axis axis)
    {
        float coord = axis == Axis.X ? input.x : input.y;
        return coord > MovementConstants.DirectionThreshold;
    }
}
