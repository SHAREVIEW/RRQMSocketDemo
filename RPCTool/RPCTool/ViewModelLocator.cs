using RRQMMVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPCTool
{
    public  class ViewModelLocator
    {

        public ViewModelLocator()
        {
           SimpleIoc.Default.Register(new MainViewModel());
        }

        public MainViewModel MainViewModel { get { return SimpleIoc.Default.GetViewModelInstance<MainViewModel>(); } }
    }
}
