using System.Collections.Generic;
using HTMLPreviewerApp.Services.Samples.Models;

namespace HTMLPreviewerApp.Services.Samples
{
    public interface ISamplesService
    {
        void Save(string code, string userId);

        IEnumerable<SampleServiceModel> All(string userId);
    }
}
