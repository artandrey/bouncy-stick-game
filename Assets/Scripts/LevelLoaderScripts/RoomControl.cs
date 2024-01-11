using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;

    [SerializeField]
    private LevelExit levelExit;

    public event Action OnRoomComplited;

    public Transform StartPoint { get => startPoint; }

    void Start()
    {
        levelExit.OnExit += DispatchRoomCompleted;
    }

    void OnDestroy()
    {
        levelExit.OnExit -= DispatchRoomCompleted;
    }

    private void DispatchRoomCompleted()
    {
        OnRoomComplited?.Invoke();
    }

}
