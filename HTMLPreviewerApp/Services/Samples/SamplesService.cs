using System;
using System.Linq;
using HTMLPreviewerApp.Data;
using System.Collections.Generic;
using HTMLPreviewerApp.Data.Models;
using HTMLPreviewerApp.Services.Samples.Models;

namespace HTMLPreviewerApp.Services.Samples
{
    public class SamplesService : ISamplesService
    {
        private const string DateTimeFormat = "MM/dd/yyyy hh:mm tt";

        private readonly PreviewerDbContext _data;

        public SamplesService(PreviewerDbContext data)
            => this._data = data;

        public void Save(string code, string userId)
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

        public IEnumerable<SampleServiceModel> All(string userId)
            => this._data
                .Samples
                .Where(s => s.UserId == userId)
                .Select(s => new SampleServiceModel
                {
                    Creation = s.Creation.ToString(DateTimeFormat),
                    LastEdit = s.LastEdit.ToString(DateTimeFormat)
                })
                .ToList();
    }
}
