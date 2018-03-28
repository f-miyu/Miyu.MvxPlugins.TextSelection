using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Platform.WeakSubscription;

namespace MvvmCross.Plugins.TextSelection.Droid.BindingTargets
{
    public class MvxEditTextSelectionTargetBinding : MvxAndroidTargetBinding<MvxEditText, int>
    {
        private IDisposable _subscription;

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public MvxEditTextSelectionTargetBinding(MvxEditText target) : base(target)
        {
        }

        protected override void SetValueImpl(MvxEditText target, int value)
        {
            target.SetSelection(value);
        }

        public override void SubscribeToEvents()
        {
            if (Target == null) return;

            _subscription = Target.WeakSubscribe<MvxEditText>(
                nameof(Target.SelectionChanged),
                (sender, e) => FireValueChanged(Target.SelectionStart)
            );
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
