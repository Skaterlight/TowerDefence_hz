using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    [SerializeField] private GameObject FireballSpell;
    [SerializeField] private GameObject SpellCaster;
    [SerializeField] private GameObject Enemy;
    private float SpellSpeed = 0.03f;
    private GameObject castedSpell;
    private float Distance;

    private void Start()
    {
        InvokeRepeating("SpawnFireball", 1f, 1.5f);
    }

    private void Update()
    {
        Distance = Vector3.Distance(SpellCaster.transform.position, Enemy.transform.position);

        if (castedSpell != null)
        {
            castedSpell.transform.position = Vector3.Lerp(castedSpell.transform.position, Enemy.transform.position, SpellSpeed);
        }
    }

    private void SpawnFireball()
    {
        if(Distance < 15f)
        {
            castedSpell = Instantiate(FireballSpell, new Vector3(SpellCaster.transform.position.x, SpellCaster.transform.position.y + 2,
              SpellCaster.transform.position.z), Quaternion.identity);
        }
    }
}
