using UnityEngine;
using Zenject;

namespace Feature.Movement
{
	public sealed class MovementInstaller : MonoInstaller
	{
		[SerializeField] InputInputListener _inputInputListener;
		
		public override void InstallBindings()
		{
			Container.Bind<IInputController>().FromInstance(_inputInputListener).AsSingle();
		}
	}
}