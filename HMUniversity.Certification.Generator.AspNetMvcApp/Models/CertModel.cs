namespace HMUniversity.Certification.Generator.AspNetMvcApp.Models
{
    public class CertModel
    {
        public string Owner { get; set; }
        public DegreeType Degree { get; set; }
    }

    public enum DegreeType
    {
        Bachelor,
        Master
    }
}