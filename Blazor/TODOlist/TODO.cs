namespace TODOlist
{
	public class TODO
	{
		public string Description { get; set; }
		public bool DONE { get; set; }
		public override bool Equals(object? other)
		{
			return 
				this.
				Description.
				Equals((other as TODO).Description, StringComparison.OrdinalIgnoreCase);
		}
	}
}
