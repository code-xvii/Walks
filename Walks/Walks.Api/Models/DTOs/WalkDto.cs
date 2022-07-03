﻿namespace Walks.Api.Models.DTOs
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
        public string Code { get; set; }
    }
}
