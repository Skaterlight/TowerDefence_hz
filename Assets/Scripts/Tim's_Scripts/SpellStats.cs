using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellStats", menuName = "Stats/SpellStats")]

public class SpellStats : ScriptableObject
{
    [SerializeField] private GameObject spell;
    public GameObject Spell => spell;

    [SerializeField] private int damage;
    public int Damage => damage;

    [SerializeField] private float speed;
    public float Speed => speed;

    [SerializeField] private int lasting;
    public int Lasting => lasting;
}
