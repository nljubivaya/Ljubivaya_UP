using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ReactiveUI;
using UP_Ljubivaya.Models;

namespace UP_Ljubivaya.ViewModels
{
	public class ShowPartnerProductVM : ViewModelBase
    {
        private Partner? _partner;
        public Partner? Partner
        {
            get => _partner;
            set => this.RaiseAndSetIfChanged(ref _partner, value);
        }

        private List<PartnersProduct>? _partnersProducts;
        public List<PartnersProduct>? PartnersProducts
        {
            get => _partnersProducts;
            set => this.RaiseAndSetIfChanged(ref _partnersProducts, value);
        }

        public ShowPartnerProductVM(int id)
        {
            _partner = MainWindowViewModel.myConnection.Partners
                .Include(x => x.PartnerTypeNavigation)
                .Include(x => x.PartnersProducts).ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == id);

            if (_partner != null)
            {
                PartnersProducts = _partner.PartnersProducts.ToList();
            }
        }

        public void ToShowPartner()
        {
            MainWindowViewModel.Instance.PageContent = new ShowPartner();
        }
    }
}