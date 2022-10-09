using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float timeToShoot = 0.4f;
    public GameObject bulletPrefab;
    
    private IEnumerator _coroutine;
    
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
}
