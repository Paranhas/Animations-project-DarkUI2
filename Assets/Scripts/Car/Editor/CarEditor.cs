using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Car))]

public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Car myTarget = (Car)target;
        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);
        myTarget.speed = EditorGUILayout.IntField("MInha velocidade", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Minha marcha", myTarget.gear);

        EditorGUILayout.LabelField("Velocidade total", myTarget.TotalSpeed.ToString());
        EditorGUILayout.HelpBox("Calcule a velocidade total do carro!", MessageType.Info);
        if (myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("Cuidado! Velocidade muito alta!", MessageType.Error);
        }

        GUI.color = Color.blue;
        if (GUILayout.Button("Criar Carro"))
            {
                myTarget.CreatCar();
            }
    }
}
