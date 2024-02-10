using System.ComponentModel.DataAnnotations;
using SocialMediaAnalysis.BLL.Enums;

namespace SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;

public class EverythingRequestModel
{
    [Required]
    public string Q { get; set; }
    public ICollection<string> SearchIn { get; set; } = new List<string>();
    public ICollection<string> Sources { get; set; } = new List<string>();
    public ICollection<string> Domains { get; set; } = new List<string>();
    public ICollection<string> ExcludeDomains { get; set; } = new List<string>();
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public Language? Language { get; set; } = Enums.Language.En;
    public SortBy? SortBy { get; set; }
    public int? PageSize { get; set; }
    public int? Page { get; set; }
}