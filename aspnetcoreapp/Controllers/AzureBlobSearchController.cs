using AspNetCoreApp.Data;
using AspNetCoreApp.Models;
using AspNetCoreApp.Services;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.Controllers;

public class AzureBlobSearchController : Controller
{
    private readonly RazorPagesCityContext _context;
    private readonly string _sas = "SharedAccessSignature=...";

    public AzureBlobSearchController()
    {
    }

    public async Task<IActionResult> Index()
    {
        // var data = new List<string>() { "Hello World", "Goodbye World" };
        SetTags();
        return View(GetAllAttributes());
    }

    public async Task<IActionResult> BlobsByTag()
    {
        // var data = new List<string>() { "Hello World", "Goodbye World" };
        // SetTags();
        return View(GetBlobsByTag());
    }

    public void SetTags()
    {
        var blobServiceClient = new BlobServiceClient(_sas);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient("superblobu");
        var blobPages = blobContainerClient.GetBlobs(BlobTraits.Metadata | BlobTraits.Tags, BlobStates.None);

        int blobCounter = 0;

        foreach (var page in blobPages.AsPages())
        {
            foreach (var blob in page.Values)
            {
                blobCounter += 1;

                if (blobCounter % 11 != 0) {
                    continue;
                }

                var blobClient = blobContainerClient.GetBlobClient(blob.Name);
                Random rnd = new Random();
                int nr = rnd.Next(100) + 1;

                blobClient.SetTags(new Dictionary<string, string>() { { "somenr", $"{nr}" } });
            }
        }
    }

    public IDictionary<string, List<string>> GetAllAttributes()
    {
        var blobServiceClient = new BlobServiceClient(_sas);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient("superblobu");
        var blobPages = blobContainerClient.GetBlobs(BlobTraits.Metadata | BlobTraits.Tags, BlobStates.None);

        var totalNrBlobs = 0;
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        var attributes = new Dictionary<string, List<string>>();
        foreach (var page in blobPages.AsPages())
        {
            foreach (var blob in page.Values)
            {
                totalNrBlobs++;

                foreach (var metadata in blob.Metadata)
                {
                    if (!attributes.ContainsKey(metadata.Key))
                    {
                        attributes.Add(metadata.Key, new List<string> { metadata.Value });
                    }
                    else
                    {
                        attributes[metadata.Key].Add(metadata.Value);
                    }
                }

                if (blob.Tags == null)
                {
                    continue;
                }

                foreach (var tag in blob.Tags)
                {
                    if (!attributes.ContainsKey(tag.Key))
                    {
                        attributes.Add(tag.Key, new List<string> { tag.Value });
                    }
                    else
                    {
                        attributes[tag.Key].Add(tag.Value);
                    }
                }
            }
        }

        stopwatch.Stop();
        attributes["totalNrBlobs"] = new List<string> { totalNrBlobs.ToString() };
        attributes["elapsedMs"] = new List<string> { stopwatch.ElapsedMilliseconds.ToString() };

        return attributes;
    }

    public IDictionary<string, List<string>> GetBlobsByTag()
    {
        var blobServiceClient = new BlobServiceClient(_sas);
        var blobPages = blobServiceClient.FindBlobsByTags("\"somenr\" > '50'");

        var totalNrBlobs = 0;
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        var attributes = new Dictionary<string, List<string>>();
        foreach (var page in blobPages.AsPages())
        {
            foreach (var blob in page.Values)
            {
                totalNrBlobs++;

                if (blob.Tags == null)
                {
                    continue;
                }

                foreach (var tag in blob.Tags)
                {
                    if (!attributes.ContainsKey(tag.Key))
                    {
                        attributes.Add(tag.Key, new List<string> { tag.Value });
                    }
                    else
                    {
                        attributes[tag.Key].Add(tag.Value);
                    }
                }
            }
        }

        stopwatch.Stop();
        attributes["totalNrBlobs"] = new List<string> { totalNrBlobs.ToString() };
        attributes["elapsedMs"] = new List<string> { stopwatch.ElapsedMilliseconds.ToString() };

        return attributes;
    }
}
