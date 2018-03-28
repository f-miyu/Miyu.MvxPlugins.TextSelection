using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace MvvmCross.Plugins.TextSelection.Droid
{
    [Register("mvvmCross.plugins.textSelection.droid.MvxEditText")]
    public class MvxEditText : EditText
    {
        public event EventHandler SelectionChanged;

        public MvxEditText(Context context) : base(context)
        {
        }

        public MvxEditText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public MvxEditText(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        protected override void OnSelectionChanged(int selStart, int selEnd)
        {
            base.OnSelectionChanged(selStart, selEnd);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
