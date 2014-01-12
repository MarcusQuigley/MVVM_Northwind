using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.ViewModel
{

    //this is a pattern impl that 
    //1. exposes your ViewModel
    //2. Instantiates that viewModel
    //3. Can also be used for cleanup
    public class ViewModelLocator
    {
        private static MainWindowViewModel _mainWindowViewModel;

        public static MainWindowViewModel MainWindowViewModelStatic
        {
            get
            {
                return _mainWindowViewModel ?? (
                 _mainWindowViewModel = new MainWindowViewModel()
                 );
            }
        }
    }
}
