using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private float _fireInterval;
    [SerializeField] private float _fireForce;
    [SerializeField] GameObject _cannonBallPrefab;
    [SerializeField] GameObject _cannonBallSpawnPosition;


    private Rigidbody _instantiatedBallRb;
    private GameObject _instantiatedBallClone;

    private void Start()
    {
        InitBall();
        StartCoroutine(CannonShoot());
    }

    private void InitBall()
    {
        _instantiatedBallClone = Instantiate(_cannonBallPrefab, _cannonBallSpawnPosition.transform.position,Quaternion.identity);
        _instantiatedBallRb = _instantiatedBallClone.GetComponent<Rigidbody>();
    }

    private IEnumerator CannonShoot()
    {
        _instantiatedBallRb.AddForce(transform.forward * _fireForce, ForceMode.VelocityChange);
        yield return new WaitForSeconds(_fireInterval);
        ResetBall();


    }

    private void ResetBall()
    {
        _instantiatedBallRb.velocity = new Vector3(0, 0, 0);
        _instantiatedBallClone.transform.position = _cannonBallSpawnPosition.transform.position;
        StartCoroutine(CannonShoot());
    }


}
