using System.ComponentModel.DataAnnotations;

namespace SellPhones.Commons
{
    public enum DATE_FILTER
    {
        [Display(Name = "Done")]
        None = 0,

        [Display(Name = "Date")]
        Date = 1,

        [Display(Name = "Month")]
        Month = 2,

        [Display(Name = "Quarter")]
        Quarter = 3,

        [Display(Name = "Year")]
        Year = 4,

        [Display(Name = "Week")]
        Week = 5,
    }

    public enum TYPE_PRODUCT
    {
        [Display(Name = "Phone")]
        PHONE = 0,
        [Display(Name = "LapTop")]
        LAPTOP = 1,
        [Display(Name = "Earphone")]
        EARPHONE = 2,
    }
}