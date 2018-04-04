using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace Miyu.MvxPlugins.TextSelection.Sample.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IMvxCommand _insertCommand;
        public IMvxCommand InsertCommand => _insertCommand ?? (_insertCommand = new MvxCommand(() =>
        {
            if (Text == null)
            {
                Text = "";
            }

            var currentSelection = Selection;
            var insertion = "text";
            Text = Text.Insert(Selection, insertion);
            Selection = currentSelection + insertion.Length;
        }));

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private int _selection;
        public int Selection
        {
            get => _selection;
            set => SetProperty(ref _selection, value);
        }
    }
}