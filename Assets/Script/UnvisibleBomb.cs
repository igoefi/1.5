using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnvisibleBomb : MonoBehaviour
{
    [SerializeField] float timeToExplosion;
    private bool _readyToExplosion;
    private bool _isExplosion;

    [SerializeField] float explosionForse;

    private readonly List<Rigidbody> boxList = new List<Rigidbody>();

    private void Start()
    {
        _readyToExplosion = false;
        _isExplosion = false;
    }

    private void Update()
    {
        if (Time.time >= timeToExplosion)
            _readyToExplosion = true;
    }

    private void FixedUpdate()
    {
        if (_readyToExplosion && !_isExplosion)
        {
            _isExplosion = true;
            foreach(Rigidbody body in boxList)
            {
                body.AddExplosionForce(explosionForse, transform.position, 0, 2, ForceMode.Impulse);
            }
        }
    }

    #region OnTrigger
    private void OnTriggerEnter(Collider other)
    {
        boxList.Add(other.GetComponent<Rigidbody>());
        Debug.Log("Box enter");
    }

    private void OnTriggerExit(Collider other)
    {
        boxList.Remove(other.GetComponent<Rigidbody>());
        Debug.Log("Box exit");
    }
    #endregion
}
