using Infrastructure;
using UnityEngine;

namespace Feature.ItemSpawner.Factory
{
	public interface ICubeFactory : IFactory
	{
		GameObject Create(Vector3 pos);
	}
}