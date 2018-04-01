# MvvmCross text selection plugin
This MvvmCross plugin provides tow-way data binding for cursor position in UITextField, UITextView or EditText.
## Usage
### Android
`MvxEditText` has `Selection` that is binding for cursor position.
```xml
<mvvmcross.plugins.textSelection.droid.MvxEditText
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    local:MvxBind="Text Text; Selection Selection" />
```
### iOS
`UITextField` and `UITextView` have `Selection` that is binding for cursor position.
```C#
set.Bind(textField).For(v => v.BindSelection()).To(vm => vm.Selection);
```
