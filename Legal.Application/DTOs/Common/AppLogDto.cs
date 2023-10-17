namespace Legal.Application.DTOs.Common
{
    public class AppLogDto
    {
        public long UserId { get; set; }

        public string? TableName { get; set; }

        public string DoingDescription { get; set; } = null!;
    }
}
