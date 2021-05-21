using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        var nextPoint = new Vector3(
            transform.position.x,
            _ball.position.y + _offsetY,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position, 
            nextPoint, 
            _speed * Time.fixedDeltaTime
        );
    }
}
