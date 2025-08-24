using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Feature.Movement
{
	public sealed class InputInputListener : MonoBehaviour, IInputController
	{
		readonly Subject<Unit> _sendMsg = new();
		readonly Subject<Unit> _spawnCube = new();
		readonly Subject<Vector2> _movementDir = new();

		public IObservable<Unit> SendMsg => _sendMsg;
		public IObservable<Unit> SpawnCube => _spawnCube;
		public IObservable<Vector2> MovementDir => _movementDir;

		void OnDestroy()
		{
			_movementDir.OnCompleted();
			_movementDir.Dispose();
		}

		void OnMove(InputValue value)
		{
			var dir = value.Get<Vector2>();
			_movementDir.OnNext(dir);
		}

		void OnJump()
		{
			_sendMsg.OnNext(Unit.Default);
		}

		void OnInteract(InputValue value)
		{
			_spawnCube.OnNext(Unit.Default);
		}
	}
}