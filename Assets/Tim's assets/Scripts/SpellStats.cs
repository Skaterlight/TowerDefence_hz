using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellStats", menuName = "Stats/SpellStats")]

public class SpellStats : ScriptableObject
{
    public GameObject spell;
    public int damage;
    public float speed;
}
