using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] GameObject _grenadePrefab;
    [SerializeField] Transform _rightHandPos;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ThrowGrenade();
    }
    void ThrowGrenade()
    {
        GameObject newGrenade = Instantiate(_grenadePrefab, new Vector3(_rightHandPos.position.x, _rightHandPos.position.y + 1f, _rightHandPos.position.z), transform.rotation);
        newGrenade.GetComponent<Rigidbody>()?.AddForce(_rightHandPos.forward, ForceMode.Impulse);
    }
}
