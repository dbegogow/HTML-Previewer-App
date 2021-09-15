using System;
using HTMLPreviewerApp.Data;
using HTMLPreviewerApp.Data.Models;

namespace HTMLPreviewerApp.Services.Samples
{
    public class SamplesService : ISamplesService
    {
        private readonly PreviewerDbContext _data;

        public SamplesService(PreviewerDbContext data)
            => this._data = data;

        public void SaveSample(string code, string userId)
        {
            var sample = new Sample
            {
                Code = code,
                UserId = userId,
                Creation = DateTime.Now,
                LastEdit = DateTime.Now
            };

            this._data
                .Samples
                .Add(sample);

            this._data.SaveChanges();
        }
    }
}
