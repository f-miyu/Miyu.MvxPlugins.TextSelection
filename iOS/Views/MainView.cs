using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Plugins.TextSelection.Sample.Core.ViewModels;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Plugins.TextSelection.iOS.Binding;

namespace MvvmCross.Plugins.TextSelection.Sample.iOS.Views
{
    [MvxFromStoryboard]
    [MvxRootPresentation]
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(TextField).To(vm => vm.Text);
            set.Bind(TextField).For(v => v.BindSelection()).To(vm => vm.Selection);
            set.Bind(InsertButton).To(vm => vm.InsertCommand);

            set.Apply();
        }
    }
}