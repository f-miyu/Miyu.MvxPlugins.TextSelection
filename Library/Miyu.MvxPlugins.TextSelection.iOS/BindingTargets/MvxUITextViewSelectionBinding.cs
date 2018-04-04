using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using UIKit;
using MvvmCross.Platform.WeakSubscription;

namespace Miyu.MvxPlugins.TextSelection.iOS.BindingTargets
{
    public class MvxUITextViewSelectionBinding : MvxConvertingTargetBinding<UITextView, int>
    {
        private IDisposable _subscription;

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public MvxUITextViewSelectionBinding(UITextView target) : base(target)
        {
        }

        public override void SubscribeToEvents()
        {
            _subscription = Target.WeakSubscribe<UITextView>(nameof(Target.Changed), UITextViewOnSelectionChanged);
        }

        protected override void SetValueImpl(UITextView target, int value)
        {
            var currentSelection = GetCurrentSelection(target);
            var position = target.GetPosition(target.SelectedTextRange.Start, value - currentSelection);

            target.SelectedTextRange = target.GetTextRange(position, position);
        }

        private int GetCurrentSelection(UITextView textView)
        {
            return (int)textView.GetOffsetFromPosition(textView.BeginningOfDocument, textView.SelectedTextRange.Start);
        }

        private void UITextViewOnSelectionChanged(object sender, EventArgs e)
        {
            var selection = GetCurrentSelection(Target);
            FireValueChanged(selection);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _subscription?.Dispose();
                _subscription = null;
            }

            base.Dispose(isDisposing);
        }
    }
}
