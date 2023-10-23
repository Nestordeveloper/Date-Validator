#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace dojo_survey_validation;
public class DojoSurvey
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Location is required!")]
    public string Location { get; set; }
    [Required(ErrorMessage = "Language is required!")]
    public string Language { get; set; }
    [MinLength(20, ErrorMessage = "Comment must be at least 20 characters in length!")]
    public string Comment { get; set; }
    [Required(ErrorMessage = "Date is required!")]
    [FutureDate]
    public DateTime DateToday { get; set; }
}

public class FutureDateAttribute : ValidationAttribute
{
    public FutureDateAttribute()
    {
        ErrorMessage = "Date must be future.";
    }

    public override bool IsValid(object value)
    {
        if (value is DateTime date)
        {
            return date > DateTime.Now;
        }

        return false;
    }
}

