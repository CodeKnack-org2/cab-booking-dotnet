using System;

namespace CabBooking.Core.DTOs
{
    public class RatingDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
        public Guid BookingId { get; set; }
        public double Score { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateRatingDto
    {
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
        public Guid BookingId { get; set; }
        public double Score { get; set; }
        public string Comment { get; set; }
    }

    public class UpdateRatingDto
    {
        public double Score { get; set; }
        public string Comment { get; set; }
    }

    public class RatingSummaryDto
    {
        public double AverageRating { get; set; }
        public int TotalRatings { get; set; }
        public int FiveStarRatings { get; set; }
        public int FourStarRatings { get; set; }
        public int ThreeStarRatings { get; set; }
        public int TwoStarRatings { get; set; }
        public int OneStarRatings { get; set; }
    }
} 