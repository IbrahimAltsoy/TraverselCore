﻿namespace TraverselCore.CORS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string DayNight { get; set; }
    }
}
