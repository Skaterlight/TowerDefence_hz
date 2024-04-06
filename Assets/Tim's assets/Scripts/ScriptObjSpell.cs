using UnityEngine;
using UnityEditor.UI;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "Spell stats", menuName = "Stats/SpellStats")] 

public class ScriptObjSpell : ScriptableObject
{
    public GameObject SpellPrefab;
    public string SpellName;
    public int Damage;
    public float Speed;
}
