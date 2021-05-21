using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _endPoint;

    public Animator Animator => _animator;
    public Transform EndPoint => _endPoint;
}
