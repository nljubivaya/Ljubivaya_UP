using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UP_Ljubivaya.ViewModels;

namespace UP_Ljubivaya;

public partial class ShowPartner : UserControl
{
    public ShowPartner()
    {
        InitializeComponent();
        DataContext = new ShowPartnerVM();
    }
}