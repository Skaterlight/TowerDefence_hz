using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    [SerializeField] private SpellStats stats;
    public int Damage => stats.Damage;
    public int Lasting => stats.Lasting;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }
}
