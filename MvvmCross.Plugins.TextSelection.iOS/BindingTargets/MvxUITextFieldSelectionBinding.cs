using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using UIKit;
using MvvmCross.Platform.WeakSubscription;
using Foundation;

namespace MvvmCross.Plugins.TextSelection.iOS.BindingTargets
{
    public class MvxUITextFieldSelectionBinding : MvxConvertingTargetBinding<UITextField, int>
    {
        private IDisposable _selectedTextRangeObserver;
        private IDisposable _editingChangedSubscription;

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public MvxUITextFieldSelectionBinding(UITextField target) : base(target)
        {
        }

        public override void SubscribeToEvents()
        {
            if (Target == null) return;

            _selectedTextRangeObserver = Target.AddObserver("selectedTextRange", NSKeyValueObservingOptions.New, (NSObservedChange obj) => FireSelectionChanged());
            _editingChangedSubscription = Target.WeakSubscribe<UITextField>(nameof(Target.EditingChanged), (sender, e) => FireSelectionChanged());
        }

        protected override void SetValueImpl(UITextField target, int value)
        {
            var currentSelection = GetCurrentSelection(target);
            var position = target.GetPosition(target.SelectedTextRange.Start, value - currentSelection);

            target.SelectedTextRange = target.GetTextRange(position, position);
        }

        private int GetCurrentSelection(UITextField textView)
        {
            return (int)textView.GetOffsetFromPosition(textView.BeginningOfDocument, textView.SelectedTextRange.Start);
        }

        private void FireSelectionChanged()
        {
            var selection = GetCurrentSelection(Target);
            FireValueChanged(selection);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _selectedTextRangeObserver?.Dispose();
                _selectedTextRangeObserver = null;

                _editingChangedSubscription?.Dispose();
                _editingChangedSubscription = null;
            }

            base.Dispose(isDisposing);
        }
    }
}
