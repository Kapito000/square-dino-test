using Feature.Movement;
using Mirror;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Player
{
	public sealed class NotLocalPlayerInit : NetworkBehaviour
	{
		[SerializeField] Movement.Movement _movement;
		[SerializeField] InputInputListener _inputInputListener;

		void Start()
		{
			Assert.IsNotNull(_movement);
			Assert.IsNotNull(_inputInputListener);

			if (!isLocalPlayer)
			{
				Destroy(_movement);
				Destroy(_inputInputListener);
				Destroy(this);
			}
		}
	}
}