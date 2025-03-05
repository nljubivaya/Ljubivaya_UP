using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using ReactiveUI;
using UP_Ljubivaya.Models;

namespace UP_Ljubivaya.ViewModels
{
	public class AddPartnerVM : ViewModelBase
    {
        private string _pageName = ""; // ���� ��� �������� ��������
        public string PageName // �������� ��� ��������
        {
            get => _pageName;
            set => this.RaiseAndSetIfChanged(ref _pageName, value);
        }
        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set => this.RaiseAndSetIfChanged(ref _isEditMode, value);
        }
        public string ButtonText
        {
            get
            {
                return IsEditMode ? "��������� ���������" : "���������";
            }
        }

        //���������� ������ ����� ��������� �� ���� ������, ��������������� � ������ ��� �������� ������ � �������.
        public List<PartnersType> PartnersTypes => MainWindowViewModel.myConnection.PartnersTypes.ToList();
        Partner? _newPartner;
        public Partner? NewPartner { get => _newPartner; set => this.RaiseAndSetIfChanged(ref _newPartner, value); }
        //�������������� ����� ��������� �������� ��� ��������� ������������� �������� �� ��������� ��������������, ������� ��������� ������ � ���� �������� � ���������
        public AddPartnerVM()
        {
            PageName = "���������� ��������";
            NewPartner = new Partner();
        }
        public AddPartnerVM(int Id)
        {
            PageName = "��������� ��������";
            _newPartner = MainWindowViewModel.myConnection.Partners
                .Include(x => x.PartnerTypeNavigation)
                .Include(x => x.PartnersProducts).ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == Id);
        }

        // ����������� ����� ��� ���������� ��� �������������� ��������.
        // ����������� � ������������ ������������� �� ���������� ���������.
        public async void AddPartner()
        {
            ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("����", "�� ������ ��������� ���������?", ButtonEnum.YesNo).ShowAsync();
            if (result == ButtonResult.Yes)
            {
                if (NewPartner.Rating < 0 || NewPartner.Rating != (int)NewPartner.Rating)
                {
                    await MessageBoxManager.GetMessageBoxStandard("������", "������� �������� ������ ���� ����� ��������������� ������.", ButtonEnum.Ok).ShowAsync();
                    return;
                }
                if (NewPartner.Id == 0)
                {
                    MainWindowViewModel.myConnection.Partners.Add(NewPartner);
                }
                MainWindowViewModel.myConnection.SaveChanges();
                MainWindowViewModel.Instance.PageContent = new ShowPartner();
                ButtonResult resultok = await MessageBoxManager.GetMessageBoxStandard("����", "��������� ������� ���������", ButtonEnum.Ok).ShowAsync();
            }
            else if (result == ButtonResult.No)
            {
                MainWindowViewModel.Instance.PageContent = new AddPartner(NewPartner.Id);
            }
        }

        public void ToShowPartner()
        {
            MainWindowViewModel.Instance.PageContent = new ShowPartner();
        }
    }
}