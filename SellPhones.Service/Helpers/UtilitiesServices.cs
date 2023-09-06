using SellPhones.Commons;

namespace SellPhones.Service.Helpers
{
    public static class UtilitiesServices
    {
        public static string ResolveMonthYear(DATE_FILTER dateFilter, int key, DateTime addedStamp)
        {
            string result = "";
            if (DATE_FILTER.Week == dateFilter)
            {
                DateTime firstDayOfMonth = new DateTime(addedStamp.Year, addedStamp.Month, 1);

                // Tìm ngày đầu tiên của tuần đầu tiên
                DateTime firstDayOfWeek = firstDayOfMonth.AddDays(-(int)firstDayOfMonth.DayOfWeek + 1);

                // Tính số tuần bằng cách lấy hiệu số ngày giữa ngày cần tính và ngày đầu tiên của tuần đầu tiên
                int weekNumber = (addedStamp - firstDayOfWeek).Days / 7 + 1;
                result = $"Tuần {weekNumber} tháng {addedStamp.Month}, Năm {addedStamp.Year}";
            }
            return dateFilter == DATE_FILTER.None ? "Tháng " + addedStamp.Month + " Năm " + addedStamp.Year :
                                    dateFilter == DATE_FILTER.Date ? addedStamp.ToString("dd/MM/yyyy") :
                                    dateFilter == DATE_FILTER.Month ? "Tháng " + key + " Năm " + addedStamp.Year :
                                    dateFilter == DATE_FILTER.Quarter ? "Quý " + key + " Năm " + addedStamp.Year :
                                    dateFilter == DATE_FILTER.Year ? "Năm " + key :
                                    dateFilter == DATE_FILTER.Week ? result : "";
        }
    }
}