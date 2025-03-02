using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UP_Ljubivaya.ViewModels;

namespace UP_Ljubivaya;

public partial class AddPartner : UserControl
{
    public AddPartner()
    {
        InitializeComponent();
        DataContext = new AddPartnerVM();
    }
}