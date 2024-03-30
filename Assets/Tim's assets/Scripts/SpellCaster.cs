using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private GameObject FireballSpell;
    [SerializeField] private GameObject Caster;
    private float SpellSpeed = 0.03f;
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
            castedSpell.transform.position = Vector3.Lerp(castedSpell.transform.position, _target.transform.position, SpellSpeed);
        }
    }

    private void SpawnFireball()
    {
        if(_target != null)
        {
            castedSpell = Instantiate(FireballSpell, new Vector3(Caster.transform.position.x, Caster.transform.position.y + 2.3f, Caster.transform.position.z), Quaternion.identity);
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
