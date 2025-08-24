using System;
using UniRx;
using UnityEngine;

namespace Feature.Movement
{
	public interface IMovementController
	{
		IObservable<Unit> SendMsg { get; }
		IObservable<Vector2> MovementDir { get; }
	}
}