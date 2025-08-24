using Feature.ItemSpawner.Factory;
using Feature.Movement;
using Mirror;
using UniRx;
using UnityEngine;
using Zenject;

namespace Feature.ItemSpawner
{
	public sealed class CubeSpawner : NetworkBehaviour
	{
		[Inject] ICubeFactory _factory;
		[Inject] IInputController _inputController;

		void Awake()
		{
			_inputController.SpawnCube
				.Subscribe(CmdSpawnCube)
				.AddTo(this);
		}

		[Command]
		void CmdSpawnCube(Unit _)
		{
			var offset = new Vector3(0, 1, 1);
			var cube = _factory.Create(transform.position + offset);
			NetworkServer.Spawn(cube);
		}
	}
}