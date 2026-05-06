using Godot;

public partial class BubbleParticles : GpuParticles2D
{
	[Export] public float BottomOffset = 24f;
	[Export] public float ResetMargin = 64f;

	public override void _Ready()
	{
		LocalCoords = false;

		var mat = ProcessMaterial as ParticleProcessMaterial;
		if (mat == null)
		{
			mat = new ParticleProcessMaterial();
			ProcessMaterial = mat;
		}

		mat.Direction = new Vector3(0, -1, 0);
		mat.InitialVelocityMin = 20f;
		mat.InitialVelocityMax = 40f;
		mat.Gravity = Vector3.Zero;

		Emitting = true;
		PlaceAtBottom();
	}

	public override void _Process(double delta)
	{
		var topOfParticles = GlobalPosition.Y + VisibilityRect.Position.Y + VisibilityRect.Size.Y;
		if (topOfParticles < -ResetMargin)
			PlaceAtBottom();
	}

	private void PlaceAtBottom()
	{
		var rect = GetViewport().GetVisibleRect();
		GlobalPosition = new Vector2(
			rect.Position.X + rect.Size.X * 0.5f,
			rect.Position.Y + rect.Size.Y + BottomOffset
		);
	}
}
