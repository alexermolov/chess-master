using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace ChessMaster
{
    public class ConfigToDynamicGridViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ColumnConfig config)
            {
                var grid = new GridView();

                foreach (var column in config.Columns)
                {
                    var binding = new Binding(column.DataField);
                    GridViewColumn gvc = new() { Header = column.Header, DisplayMemberBinding = binding };
                    //gvc.SetValue(GridViewSort.PropertyNameProperty, binding.Path.Path);
                    grid.Columns.Add(gvc);
                }
                return grid;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
