using UnityEngine;
using Zenject;

namespace Feature.Movement
{
	public sealed class MovementInstaller : MonoInstaller
	{
		[SerializeField] MovementInputListener movementInputListener;
		
		public override void InstallBindings()
		{
			Container.Bind<IMovementController>().FromInstance(movementInputListener).AsSingle();
		}
	}
}