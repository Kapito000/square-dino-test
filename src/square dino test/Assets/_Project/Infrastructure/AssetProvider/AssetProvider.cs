using UnityEngine;

namespace Infrastructure.AssetProvider
{
	[CreateAssetMenu(menuName = "Static data/" + nameof(AssetProvider))]
	public sealed class AssetProvider : ScriptableObject, IAssetProvider
	{
		[field: SerializeField] public GameObject Player { get; private set; }
	}
}