﻿using MoviePrediction.Services.Photo;
using SQLite;
using System;

namespace MoviePrediction.Models
{
    public class HistoryPreview : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TheMovieDbId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(25)]
        public string ReleaseDate { get; set; }

        public string PosterPath { get; set; }

        public double VoteAverage { get; set; }

        [Ignore]
        public Uri PosterUrl
        {
            get
            {
                var imageUrl = new ImageUrl();
                var fullPath = imageUrl.CreatePosterLink(PosterPath, ImageUrl.PosterSize.w185);
                var link = new Uri(fullPath);

                return link;
            }
        }
    }
}
