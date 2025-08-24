using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Feature.Movement
{
	public sealed class MovementInputListener : MonoBehaviour, IMovementController
	{
		readonly Subject<Unit> _sendMsg = new();
		readonly Subject<Vector2> _movementDir = new();

		public IObservable<Unit> SendMsg => _sendMsg;
		public IObservable<Vector2> MovementDir => _movementDir;

		void OnMove(InputValue value)
		{
			var dir = value.Get<Vector2>();
			_movementDir.OnNext(dir);
		}

		void OnJump(InputValue value)
		{
			_sendMsg.OnNext(Unit.Default);
		}

		void OnDestroy()
		{
			_movementDir.OnCompleted();
			_movementDir.Dispose();
		}
	}
}