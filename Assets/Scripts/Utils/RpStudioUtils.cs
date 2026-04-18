using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public static class RpStudioUtils
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("RPStudio/Test")]
    public static void Test()
    {
        Debug.Log("Test");
    }
    [UnityEditor.MenuItem("RPStudio/Test2 %g")]
    public static void Test2()
    {
        Debug.Log("Test2");
    }
#endif
    public static void Scale(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }
    #region RANDOM STUFF
    public static T GetRandom<T>(this T[] array)
    {
        if(array.Length == 0)
            return default(T);
        return array[Random.Range(0, array.Length)];
    }
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    #endregion
}
