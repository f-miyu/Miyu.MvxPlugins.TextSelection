using System;
using UIKit;
namespace MvvmCross.Plugins.TextSelection.iOS.Binding
{
    public static class MvxIosTextSelectionPropertyBindingExtensions
    {
        public static string BindSelection(this UITextField textField) => MvxIosTextSelectionPropertyBinding.UITextField_Selection;
        public static string BindSelection(this UITextView textView) => MvxIosTextSelectionPropertyBinding.UITextView_Selection;
    }
}
