using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using UP_Ljubivaya.Models;

namespace UP_Ljubivaya.ViewModels
{
	public class ShowPartnerVM : ViewModelBase
    {
        List<Partner> _partnerList;
        public List<Partner> PartnerList { get => _partnerList; set => this.RaiseAndSetIfChanged(ref _partnerList, value); }
        public ShowPartnerVM()
        {
            PartnerList = MainWindowViewModel.myConnection.Partners.
                                                               Include(x => x.PartnerTypeNavigation).
                                                               Include(x => x.PartnersProducts).ThenInclude(x => x.Product).
                                                               ToList();
        }

        public void ToAddPartner()
        {
            MainWindowViewModel.Instance.PageContent = new AddPartner();
        }
        public void ToUpdatePartner(int Id)
        {
            MainWindowViewModel.Instance.PageContent = new AddPartner(Id);
        }
        public void ToShowPartnerProduct(int Id)
        {
            MainWindowViewModel.Instance.PageContent = new ShowPartnerProduct(Id);
        }
    }
}