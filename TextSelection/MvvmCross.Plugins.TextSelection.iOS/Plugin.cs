using System;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using UIKit;

namespace MvvmCross.Plugins.TextSelection.iOS
{
    [Preserve(AllMembers = true)]
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(RegisterTargetBindings);
        }

        private void RegisterTargetBindings(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<UITextView>(Binding.MvxIosTextSelectionPropertyBinding.UITextView_Selection, view => new BindingTargets.MvxUITextViewSelectionBinding(view));
            registry.RegisterCustomBindingFactory<UITextField>(Binding.MvxIosTextSelectionPropertyBinding.UITextField_Selection, view => new BindingTargets.MvxUITextFieldSelectionBinding(view));
        }
    }
}
