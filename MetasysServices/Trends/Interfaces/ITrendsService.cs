using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    public interface ITrendsService
    {
        List<string>GetTrendedAttributes(Guid id);
        List<Sample> GetSamples(Guid objectId, Guid attributeId, DateTime startTime, DateTime endTime);
    }
}
