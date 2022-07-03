namespace Walks.Api.Models.DTOs
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public RegionDto Region { get; set; }
        public WalkDifficultyDto WalkDifficulty { get; set; }
    }

    public class WalkDifficultyDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }

    public class AddWalkDifficultyRequestDto
    {
        public string Code { get; set; }
    }

    public class UpdateWalkDifficultyRequestDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }
}
