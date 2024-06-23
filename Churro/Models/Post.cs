using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Churro.Models
{
	[Table("posts")]
	public class Post : BaseModel
	{
		[PrimaryKey("Id")]
		public int Id { get; set; }

		[Column("CreatedAt")]
		public DateTime CreatedAt { get; set; }

		[Column("Title")]
		public string Title { get; set; }
    }
}