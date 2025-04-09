using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PizzaMVVM.Conventers
{
    // <local:ValueToVisibilityConverter x:Key="MyConverter" Negate="True" FalseVisibility="Hidden"/>
   /// <summary>
   /// преобразует булево значение в значение видимости UI элемента
   /// </summary>
    internal class BoolToVisibilityConverter : IValueConverter
    {
        public bool Negate { get; set; }//принимаемый параметр инверсии конвертации с View
        public Visibility FalseVisibility { get; set; } = Visibility.Collapsed; //итоговый формат отображения U

        #region IValieConverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool bVal)
            {
                if (Negate)// инверсие результата
                    return bVal ? FalseVisibility : Visibility.Visible;
                else //без инверсии результата
                    return bVal ? Visibility.Visible : FalseVisibility;
            }
            return FalseVisibility;// если на вход пришло что угодно кроме bool - то не отображаем элемент
        }
        //не реализован. преобразование только одностороннее
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
