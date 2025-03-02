using Avalonia.Controls;
using ReactiveUI;
using UP_Ljubivaya.Models;

namespace UP_Ljubivaya.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance;

        public static _43pLjubivayaUpContext myConnection = new _43pLjubivayaUpContext();
        public MainWindowViewModel()
        {
            Instance = this;

        }
        UserControl _pageContent = new ShowPartner();

        public UserControl PageContent
        {
            get => _pageContent;
            set => this.RaiseAndSetIfChanged(ref _pageContent, value);
        }
    }
}
