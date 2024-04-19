using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    [SerializeField] private SpellStats stats;
    public int Damage => stats.Damage;
}
