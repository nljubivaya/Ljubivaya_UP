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
        private string _pageName = ""; // Поле для хранения значения
        public string PageName // Свойство для привязки
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
                return IsEditMode ? "Сохранить изменения" : "Сохранить";
            }
        }

        //Возвращает список типов партнеров из базы данных, преобразованный в список для удобства работы с данными.
        public List<PartnersType> PartnersTypes => MainWindowViewModel.myConnection.PartnersTypes.ToList();
        Partner? _newPartner;
        public Partner? NewPartner { get => _newPartner; set => this.RaiseAndSetIfChanged(ref _newPartner, value); }
        //Инициализирует новый экземпляр партнера или загружает существующего партнера по заданному идентификатору, включая связанные данные о типе партнера и продуктах
        public AddPartnerVM()
        {
            PageName = "Добавление партнера";
            NewPartner = new Partner();
        }
        public AddPartnerVM(int Id)
        {
            PageName = "Изменение партнера";
            _newPartner = MainWindowViewModel.myConnection.Partners
                .Include(x => x.PartnerTypeNavigation)
                .Include(x => x.PartnersProducts).ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == Id);
        }

        // Асинхронный метод для добавления или редактирования партнера.
        // Запрашивает у пользователя подтверждение на сохранение изменений.
        public async void AddPartner()
        {
            ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("Окно", "Вы хотите сохранить изменения?", ButtonEnum.YesNo).ShowAsync();
            if (result == ButtonResult.Yes)
            {
                if (NewPartner.Rating < 0 || NewPartner.Rating != (int)NewPartner.Rating)
                {
                    await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Рейтинг партнера должен быть целым неотрицательным числом.", ButtonEnum.Ok).ShowAsync();
                    return;
                }
                if (NewPartner.Id == 0)
                {
                    MainWindowViewModel.myConnection.Partners.Add(NewPartner);
                }
                MainWindowViewModel.myConnection.SaveChanges();
                MainWindowViewModel.Instance.PageContent = new ShowPartner();
                ButtonResult resultok = await MessageBoxManager.GetMessageBoxStandard("Окно", "Изменения успешно сохранены", ButtonEnum.Ok).ShowAsync();
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