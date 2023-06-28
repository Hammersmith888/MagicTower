using UnityEngine.UI;

namespace UI
{
	/// <summary>
	/// Component that can be used instead of transparent Image for recieving  GraphicCaster'е raycasts. 
	/// This component ignore render logic.
	/// </summary>
	public class NonRenderedGraphic : Graphic
	{
		public override void SetMaterialDirty( )
		{
			return;
		}

		public override void SetVerticesDirty( )
		{
			return;
		}

		protected override void OnPopulateMesh( VertexHelper vh)
		{
			vh.Clear();
			return;
		}
	}
}