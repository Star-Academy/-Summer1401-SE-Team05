using Microsoft.AspNetCore.Mvc;
using SampleLibrary;

namespace ASP.Controllers;

[ApiController]
[Route("[controller]/hoho")]
public class InvertedIndexController : ControllerBase
{
    private IInvertedIndex _invertedIndex;
    private FileReader _fileReader = new(@"Resources");

    public InvertedIndexController(IInvertedIndex invertedIndex)
    {
        _invertedIndex = invertedIndex;
    }
    private void Initialize()
    {
        _invertedIndex.createIndex(_fileReader.ReadFiles());
    }


    [HttpGet]
        public IEnumerable<string> Get(string query)
        {
            Initialize();
            var documentChecker = new DocumentChecker(_invertedIndex);
            return documentChecker.GetValidDocuments(new ContainerBuilder(query.ToUpper()).GetContainer());
        }
}