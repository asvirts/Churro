

using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Churro.Models
{
	[Table("posts")]
	class Post : BaseModel
	{
		[PrimaryKey("Id")]
		public int Id { get; set; }

		[Column("CreatedAt")]
		public string CreatedAt { get; set; }

		[Column("Title")]
		public int Title { get; set; }
	}
}
