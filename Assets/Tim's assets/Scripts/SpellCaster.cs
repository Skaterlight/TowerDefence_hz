using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] SpellStats spellStats;
    [SerializeField] private GameObject Caster;
    private GameObject castedSpell;
    private GameObject _target;
    public GameObject Target {  get { return _target; } set { _target = value; } }

    private void Start()
    {
        InvokeRepeating("SpawnFireball", 1f, 1.5f);
    }

    private void Update()
    {
        if(castedSpell != null && _target != null)
        {
            castedSpell.transform.position = Vector3.Lerp(castedSpell.transform.position, _target.transform.position, spellStats.speed);
        }
    }

    private void SpawnFireball()
    {
        if(_target != null)
        {
            castedSpell = Instantiate(spellStats.spell, new Vector3(Caster.transform.position.x, Caster.transform.position.y + 5.3f, Caster.transform.position.z), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && _target == null)
        {
            _target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && _target != null)
        {
            _target = null;
            if(castedSpell != null)
            {
                Destroy(castedSpell);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && _target == null)
        {
            _target = other.gameObject;
        }
    }
}
