using System;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace Miyu.MvxPlugins.TextSelection.Droid
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
            registry.RegisterCustomBindingFactory<MvxEditText>(Binding.MvxAndroidTextSelectionPropertyBinding.EditText_Selection, view => new BindingTargets.MvxEditTextSelectionTargetBinding(view));
        }
    }
}
