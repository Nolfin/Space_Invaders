using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static float timeToShoot = 2f;
    public GameObject bulletPrefab;
    
    private IEnumerator _coroutine;
    private IEnumerator _boostCoroutine = BoostActivate();
    private static bool _isBoostReady = true;
    
    void Start()
    {
        _coroutine = PlayerShoot();
        StartCoroutine(_coroutine);
    }

    IEnumerator PlayerShoot()
    {
        while(true)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeToShoot);
        }
    }

    public void BoostTapped()
    {
        if(_isBoostReady) StartCoroutine(_boostCoroutine);
    }

    static IEnumerator BoostActivate()
    {
        _isBoostReady = false;
        timeToShoot = 1;
        yield return new WaitForSeconds(5);
        timeToShoot = 2;
        yield return new WaitForSeconds(40);
        _isBoostReady = true;
    }
}
