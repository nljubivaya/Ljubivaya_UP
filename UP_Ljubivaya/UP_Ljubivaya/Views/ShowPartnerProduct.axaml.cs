using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UP_Ljubivaya.ViewModels;

namespace UP_Ljubivaya;

public partial class ShowPartnerProduct : UserControl
{
    public ShowPartnerProduct(int Id)
    {
        InitializeComponent();
        DataContext = new ShowPartnerProductVM(Id);
    }
}