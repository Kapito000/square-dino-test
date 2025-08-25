using System;
using UniRx;
using UnityEngine;

namespace Feature.Movement
{
	public interface IInputController
	{
		IObservable<Unit> SendMsg { get; }
		IObservable<Unit> SpawnCube { get; }
		IObservable<Vector2> MovementDir { get; }
	}
}