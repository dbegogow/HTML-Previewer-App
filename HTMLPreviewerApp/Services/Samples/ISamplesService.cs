using System.Collections.Generic;
using HTMLPreviewerApp.Services.Samples.Models;

namespace HTMLPreviewerApp.Services.Samples
{
    public interface ISamplesService
    {
        void Save(string code, string userId);

        void Edit(
            string sampleId,
            string code,
            string userId);

        bool IsSampleExist(string sampleId, string userId);

        SampleCodeServiceModel SampleCode(string sampleId);

        IEnumerable<SampleInfoServiceModel> All(string userId);
    }
}
