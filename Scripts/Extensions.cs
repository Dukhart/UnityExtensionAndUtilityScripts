using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    // Color Extension
    public static Color Random()
    {
        return new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
    // List Extension
    public static T GetItem<T>(this List<T> list, T item)
    {
        return list[list.IndexOf(item)];
    }
    // vector extension
    public static float DistanceTo (this Vector2 vector, Vector2 target)
    {
        return Vector2.SqrMagnitude(target - vector);
    }
    public static float DistanceTo(this Vector3 vector, Vector3 target)
    {
        return Vector3.SqrMagnitude(target - vector);
    }
}
