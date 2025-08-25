using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.Common
{
	public sealed class RigidbodyInstaller : MonoInstaller
	{
		[SerializeField] Rigidbody _rigidbody;

		public override void InstallBindings()
		{
			Assert.IsNotNull(_rigidbody);
			Container
				.Bind<Rigidbody>()
				.FromInstance(_rigidbody)
				.AsSingle();
		}
	}
}