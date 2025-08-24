using Feature.Movement;
using Mirror;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Player
{
	public sealed class NotLocalPlayerInit : NetworkBehaviour
	{
		[SerializeField] Movement.Movement movement;
		[SerializeField] MovementInputListener movementInputListener;

		void Start()
		{
			Assert.IsNotNull(movement);
			Assert.IsNotNull(movementInputListener);

			if (!isLocalPlayer)
			{
				Destroy(movement);
				Destroy(movementInputListener);
				Destroy(this);
			}
		}
	}
}