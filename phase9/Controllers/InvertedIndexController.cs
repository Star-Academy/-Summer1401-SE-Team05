using Microsoft.AspNetCore.Mvc;
using SampleLibrary;

namespace ASP.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class InvertedIndexController : ControllerBase
{
    private InvertedIndex _invertedIndex = new ();
    private FileReader _fileReader = new(@"Resources");

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