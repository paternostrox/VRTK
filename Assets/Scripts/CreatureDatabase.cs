using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureDatabase", menuName = "GameData/CreatureDatabase")]
public class CreatureDatabase : ScriptableObject
{
    public GameObject[] creatures;

    public GameObject GetRandomCreature()
    {
        int index = Random.Range(0, creatures.Length);
        return creatures[index];
    }
}
