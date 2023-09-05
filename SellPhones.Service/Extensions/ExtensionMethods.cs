using System.Reflection;
using System.ComponentModel.DataAnnotations;
using SellPhones.DTO.Commons;
using System.Globalization;
using System.Text;

namespace SellPhones.Services.Extensions
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Sort<T>(this IEnumerable<T>? list, SortOption? SortOption)
        {
            if (list != null && SortOption != null)
            {
                var propertyInfo = typeof(T).GetProperty(SortOption.Column);

                if (propertyInfo != null)
                {
                    if (SortOption.Direction == "asc") list = list.OrderBy(x => propertyInfo.GetValue(x, null));
                    else if (SortOption.Direction == "desc") list = list.OrderByDescending(x => propertyInfo.GetValue(x, null));
                }
            }

            return list;
        }

        public static IEnumerable<object> GetValues<T>(IEnumerable<T> items, string propertyName)
        {
            Type type = typeof(T);
            var prop = type.GetProperty(propertyName);
            foreach (var item in items)
                yield return prop.GetValue(item, null);
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, List<FilterOption> FilterOptions, string search = "")
        {
            if (list != null && FilterOptions != null)
            {
                foreach (var filter in FilterOptions)
                {
                    if (filter.Value?.Trim() == "") continue;

                    if (filter.Value == null)
                    {
                        var propertyInfo = typeof(T).GetProperty(filter.Column);
                        if (propertyInfo == null) continue;

                        list = list.Where(x => propertyInfo.GetValue(x, null) != null ? false : true);
                    }
                    else
                    {
                        if (filter.Column.Contains('.'))
                        {
                            var arr = filter.Column.Split('.');
                            var typeInfo = typeof(T);

                            var propertyInfo = typeof(T).GetProperty(arr[0]);
                            var propertyInfoObj = typeof(T).GetProperty(arr[0]);

                            for (int i = 1; i < arr.Count(); i++)
                            {
                                propertyInfo = propertyInfo.PropertyType.GetProperty(arr[i]);

                                if (propertyInfo == null) break;

                                if (i == (arr.Count() - 1) && propertyInfo != null)
                                {
                                    list = list.
                                        Where(x => propertyInfoObj?.GetType() != null ?
                                                        (propertyInfoObj.GetValue(x, null) != null ?
                                                            (propertyInfo.GetValue(propertyInfoObj.GetValue(x, null), null) != null ?
                                                                propertyInfo.GetValue(propertyInfoObj.GetValue(x, null), null).ToString().ToLower().Contains(filter.Value.ToLower())
                                                            : false)
                                                        : false)
                                                    : false);
                                }
                            }
                        }
                        else
                        {
                            var propertyInfo = typeof(T).GetProperty(filter.Column);
                            if (propertyInfo == null) continue;

                            list = list.Where(x => propertyInfo.GetValue(x, null) != null ? propertyInfo.GetValue(x, null).ToString().ToLower().Contains(filter.Value.ToLower()) : false);
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower().Trim();
                    var listPro = new List<PropertySearchInfo>();
                    foreach (var filter in FilterOptions)
                    {
                        if (filter.Column.Contains('.'))
                        {
                            var arr = filter.Column.Split('.');
                            var typeInfo = typeof(T);

                            var propertyInfo = typeof(T).GetProperty(arr[0]);
                            var propertySearchInfo = new PropertySearchInfo(propertyInfo);
                            GetObj(propertySearchInfo, propertyInfo, arr, 1);
                            listPro.Add(propertySearchInfo);
                        }
                        else
                        {
                            var propertyInfo = typeof(T).GetProperty(filter.Column);

                            if (propertyInfo == null) continue;
                            listPro.Add(new PropertySearchInfo(propertyInfo));
                        }
                    }

                  list = list.Where(x => listPro.Any(y => CheckValue(y, x, search)));
                }
            }

            return list;
        }

        static void GetObj(PropertySearchInfo obj, PropertyInfo typeInfo, string[] arr, int i)
        {
            if (arr.Length >= i + 1)
            {
                var propertyInfo = typeInfo.PropertyType.GetProperty(arr[i]);
                if (propertyInfo != null)
                    obj.Child = new PropertySearchInfo(propertyInfo);
                GetObj(obj.Child, propertyInfo, arr, i + 1);
            }
        }

        static bool CheckValue(PropertySearchInfo x, object obj, string search)
        {
            if (x.PropertyInfo == null || obj == null) return false;

            var flag = x.PropertyInfo.GetValue(obj, null) != null ? true : false;          
            if (flag)
            {         
                var value = x.PropertyInfo.GetValue(obj, null);
                var check = value.ToString().ToLower().Contains(search);
                
                if (x.Child != null && value != null)
                    return CheckValue(x.Child, value, search);
                else
                {
                    if (!check)
                    {
                        if (HasDiacritics(search) == false)
                        {
                            var removeDiacriticsValue = RemoveDiacritics(value.ToString().ToLower());
                            search = RemoveDiacritics(search);
                            return removeDiacriticsValue.ToString().ToLower().Contains(search);
                        }
                        return check;
                    }
                }

                return value.ToString().ToLower().Contains(search);         
            }

            return false;
        }

        public static bool HasDiacritics(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);

            foreach (char c in normalizedString)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category == UnicodeCategory.NonSpacingMark || category == UnicodeCategory.SpacingCombiningMark)
                {
                    return true;
                }
            }

            return false;
        }

        public static string RemoveDiacritics(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        public class PropertySearchInfo
        {
            public PropertyInfo PropertyInfo { get; set; }
            public PropertySearchInfo? Child { get; set; }

            public PropertySearchInfo(PropertyInfo propertyInfo)
            {
                this.PropertyInfo = propertyInfo;
            }

            public PropertySearchInfo(PropertyInfo propertyInfo, PropertySearchInfo child)
            {
                this.PropertyInfo = propertyInfo;
                this.Child = child;
            }
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            if (enumValue == null)
                return "";
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }

        public static bool IsPastTime(this DateTime? time, int minute)
        {
            return DateTime.UtcNow.AddMinutes(-minute) > time;
        }
    }
}
