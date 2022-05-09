using System;
using System.Globalization;
using System.Windows.Data;

namespace MessMgmt
{
    public class Convertor
    {

    }

    public class Int2MealType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((uint)value)
            {
                case 0: return "Breakfast";
                case 1: return "Lunch";
                case 2: return "Dinner";
                case 3: return "Breakfast|Lunch|Dinner";
                case 4: return "Breakfast|Lunch ";
                case 5: return "Breakfast|Dinner ";
                case 6: return "Lunch|Dinner ";


            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Breakfast": return 0;
                case "Lunch": return 1;
                case "Dinner": return 2;
                case "Breakfast|Lunch|Dinner": return 3;
                case "Breakfast|Lunch ": return 4;
                case "Breakfast|Dinner": return 5;
                case "Lunch|Dinner": return 6;
                  

            }
            return null;
        }
    }

    public class DateTimeToDateOnlyString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime)value;
            return dateTime.ToString("dd'/'MM'/'yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (string)value;
            return DateTime.Parse(dateTime);
        }
    }

}

