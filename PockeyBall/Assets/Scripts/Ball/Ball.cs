using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Stick _stick;
    [SerializeField] private float _maxJumpForce;

    private Rigidbody _rigidbody;
    private Stick _createdStick;
    private float _jumpCharge;
    private float _distanceToTower;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _distanceToTower = transform.position.z;
        _createdStick = Hook();
    }

    private void Update()
    {
        if (_createdStick == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _createdStick = Hook();
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                ChargeUp();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Destroy(_createdStick.gameObject);
                Jump();
            }
        }
    }

    private Stick Hook()
    {
        Stick stick = null;

        var ray = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Segment segment))
            {
                _rigidbody.isKinematic = true;
                _rigidbody.velocity = Vector3.zero;
                stick = Instantiate(_stick, hit.point, _stick.transform.rotation);
            }
            else if (hit.collider.TryGetComponent(out Block block))
            {
                _rigidbody.velocity = Vector3.zero;
                var tempStick = Instantiate(_stick, hit.point, _stick.transform.rotation);
                Destroy(tempStick.gameObject, Time.deltaTime * 2);
            }

            if (hit.collider.TryGetComponent(out Finish finish))
            {
                finish.Complete();
            }
        }

        return stick;
    }

    private void ChargeUp()
    {
        _jumpCharge += Time.deltaTime;
        _jumpCharge = Mathf.Clamp(_jumpCharge, 0, 1);
        _createdStick.Animator.SetFloat("Blend", _jumpCharge);

        var scale = transform.localScale / 4;
        scale.x = 0;
        transform.position = _createdStick.EndPoint.position - scale;
    }

    private void Jump()
    {
        var position = transform.position;
        position.z = _distanceToTower;
        transform.position = position;

        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * _maxJumpForce * _jumpCharge);
        _jumpCharge = 0;
    }
}