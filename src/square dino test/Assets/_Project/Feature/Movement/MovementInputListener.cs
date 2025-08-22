using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Feature.Movement
{
	public sealed class MovementInputListener : MonoBehaviour, IMovementController
	{
		readonly Subject<Vector2> _movementDir = new();

		public IObservable<Vector2> MovementDir => _movementDir;

		public void OnMove(InputValue value)
		{
			var dir = value.Get<Vector2>();
			_movementDir.OnNext(dir);
		}

		void OnDestroy()
		{
			_movementDir.OnCompleted();
			_movementDir.Dispose();
		}
	}
}